    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.XR.ARFoundation;
    public class SomeClassOnMyARSessionOriginThatContainsMyARCamera : MonoBehaviour
    {     
     public ARCameraManager arCameraManager;//its another child go
     public ARRaycastManager arRaycastManager;
     private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
     private Vector2 touchPosition = default;
     public GameObject startPoint;
     public GameObject endPoint;
     public GameObject startPointbyJoy;
     public GameObject endPointbyJoy;
     public GameObject finger;//It´s a UICanvas
     public float vel;
     void Update()
     {        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        finger.GetComponent<RectTransform>().anchoredPosition += new Vector2(h * vel * Time.deltaTime, v * vel * Time.deltaTime);
        if (Input.GetKey(KeyCode.JoystickButton13))
        {
            touchPosition = new Vector2(GetScreenPosition(finger).x, GetScreenPosition(finger).y);//here I use that method
            if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
            {
                startPointbyJoy.SetActive(true);
                Pose hitPose = hits[0].pose;
                startPointbyJoy.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
            }
        }
        if (Input.GetKey(KeyCode.JoystickButton12))
        {            
            touchPosition = new Vector2(GetScreenPosition(finger).x, GetScreenPosition(finger).y);//here too
            if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
            {
                endPointbyJoy.SetActive(true);
                Pose hitPose = hits[0].pose;
                endPointbyJoy.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
            }
        }
        if (Input.touchCount > 0)//these are OK
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchPosition = touch.position;
                if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    startPoint.SetActive(true);
                    Pose hitPose = hits[0].pose;
                    startPoint.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
                }
            }
            if(touch.phase == TouchPhase.Moved)
            {
                touchPosition = touch.position;                
                if(arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {                    
                    endPoint.SetActive(true);
                    Pose hitPose = hits[0].pose;
                    endPoint.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
                }
            }
        }
    }
    public Vector3 GetScreenPosition(GameObject finger)
    {
    //HERE. Which "transform" should I get? The UICancas finger?
    //The go this script is attached to?
        Transform _transform = finger.GetComponent<Transform>();
        RectTransform rectTransform = (RectTransform)_transform;
        Vector4 worldLocation = _transform.localToWorldMatrix * new  Vector4(rectTransform.anchoredPosition3D.x,
                                                        rectTransform.anchoredPosition3D.y,
                                                        rectTransform.anchoredPosition3D.z,
                                                       1);
        //is it different using a arcamera?
        return arCameraManager.GetComponent<Camera>().WorldToScreenPoint(new Vector3(worldLocation.x, worldLocation.y, worldLocation.z));
     }
    }
