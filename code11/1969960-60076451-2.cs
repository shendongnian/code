    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class MultiTouch: MonoBehaviour
    {
        float initialFingersDistance;
        Vector3 initialScale;
        float rotationRate = 0.2f;
        int direction = 1;
        void LateUpdate()
        {
            if (Input.touches.Length == 1)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Touch touch = Input.touches[0];
    
                    Quaternion desiredRotation = transform.rotation;
    
                    TouchLogic.Calculate();
    
                    if (Mathf.Abs(TouchLogic.turnAngleDelta) > 0)
                    { // rotate
                       Vector3 rotationDeg = transform.eulerAngles;
    
                       rotationDeg.z = -TouchLogic.turnAngleDelta;
                       desiredRotation *= Quaternion.Euler(rotationDeg);
                    }
    
                   // not so sure those will work:
                      transform.rotation = desiredRotation;
    
    
                   // transform.Rotate(touch.deltaPosition.y * rotationRate, -touch.deltaPosition.x * rotationRate, 0, Space.World);
                       Vector3 rot = new Vector3(touch.deltaPosition.y * rotationRate, -touch.deltaPosition.x * rotationRate, transform.eulerAngles.z* rotationRate);
                    //  transform.rotation = Quaternion.EulerAngles(rot);
    
                }
            }
    
            else if (Input.touches.Length == 2)
            {
                Touch t1 = Input.touches[0];
                Touch t2 = Input.touches[1];
    
                if (t1.phase == TouchPhase.Began || t2.phase == TouchPhase.Began)
                {
                    initialFingersDistance = Vector2.Distance(t1.position, t2.position);
                    initialScale = gameObject.transform.localScale;
                }
    
                else if (t1.phase == TouchPhase.Moved || t2.phase == TouchPhase.Moved)
                {
                    var currentFingersDistance = Vector2.Distance(t1.position, t2.position);
                    //   Debug.Log(currentFingersDistance);
                    ////if (currentFingersDistance != initialFingersDistance) 
                    //{
                    var scaleFactor = currentFingersDistance / initialFingersDistance;
                    gameObject.transform.localScale = initialScale * scaleFactor;
                    //} 
    
                    float Dx = t1.position.x - transform.position.x;
                    float Dy = t1.position.y - transform.position.y;
    
       
                    //var cameraTransform = Camera.main.transform.InverseTransformPoint(0, 0, 0);
                    //transform.position = Camera.main.ScreenToWorldPoint(new Vector3(t2.position.x, t2.position.y, cameraTransform.z -0.5f));
    
       
                    Vector3 pos = t2.position;
    
                    //Vector3 pos = t1.position - t2.position;
                    Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10));
                       transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * 4);
                 //   transform.position += touchedPos;
    
                    float pinchAmount = 0;
                    Quaternion desiredRotation = transform.rotation;
    
                    TouchLogic.Calculate();
    
                    if (Mathf.Abs(TouchLogic.pinchDistanceDelta) > 0)
                    { // zoom
                        pinchAmount = TouchLogic.pinchDistanceDelta;
                    }
    
                    if (Mathf.Abs(TouchLogic.turnAngleDelta) > 0)
                    { // rotate
                        Vector3 rotationDeg = Vector3.zero;
                        rotationDeg.z = -TouchLogic.turnAngleDelta;
                        desiredRotation *= Quaternion.Euler(rotationDeg);
                    }
    
                    // not so sure those will work:
                    transform.rotation = desiredRotation;
                    transform.position += Vector3.forward * pinchAmount;
                }
            }
        }
    }
