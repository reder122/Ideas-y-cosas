using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carControl : MonoBehaviour
{
  [System.Serializable]
  public class infoEje
  {
    public WheelCollider ruedaIzquierda;
    public WheelCollider ruedaDerecha;
    public bool motor;
    public bool direccion;

  }

  public List<infoEje> infoEjes;
  public float maxMotortorsion;
  public float maxAnguloDeGiro;

  void posRuedas(WheelCollider collider)
  {
    if(collider.transform.childCount == 0)
    {
      return;
    }

    Transform ruedaVisual = collider.transform.GetChild(0);

    Vector3 posicion;
    Quaternion rotacion;
    collider.GetWorldPose(out posicion, out rotacion);

    ruedaVisual.transform.position = posicion;
    ruedaVisual.transform.rotation = rotacion;
  }

  /// <summary>
  /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
  /// </summary>
  private void FixedUpdate()
  {
    float motor = maxMotortorsion * Input.GetAxis("Vertical");
    float direccion = maxAnguloDeGiro * Input.GetAxis("Horizontal");

    foreach(infoEje ejesInfo in infoEjes)
    {
      if(ejesInfo.direccion)
      {
        ejesInfo.ruedaIzquierda.steerAngle = direccion;
        ejesInfo.ruedaDerecha.steerAngle = direccion;
      }
      if(ejesInfo.motor)
      {
        ejesInfo.ruedaIzquierda.motorTorque = motor;
        ejesInfo.ruedaDerecha.motorTorque = motor;
      }

      posRuedas(ejesInfo.ruedaIzquierda);
      posRuedas(ejesInfo.ruedaDerecha);
        
    }
    
  }
}
