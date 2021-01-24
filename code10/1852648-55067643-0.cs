using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ibuprogames.CameraTransitionsAsset;
public class SwipeColliderScript : MonoBehaviour {
    [HideInInspector]
    public float mouseDistance;
    Vector3 lastPosition;
    bool trackMouse;
    [HideInInspector]
    public bool isSwipe;
    [HideInInspector]
    public bool swipeRight;
    [HideInInspector]
    public bool swipeLeft;
    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            if (Input.touchCount == 1)
            {
                Debug.LogError("touch down registered");
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    trackMouse = true;
                    isSwipe = false;
                    lastPosition = touch.position;
                    Debug.LogError("Mouse down registered");
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    trackMouse = false;
                    Debug.LogError(@"Swipe held for " + mouseDistance + "pixels!");
                    mouseDistance = 0;
                }
                if (trackMouse)
                {
                    Vector3 newPosition = touch.position;
                    mouseDistance += (newPosition.x - lastPosition.x);
                    if (mouseDistance > 20 || mouseDistance < -20)
                    {
                        isSwipe = true;
                    }
                    if (mouseDistance > 20)
                    {
                        swipeLeft = true;
                        swipeRight = false;
                    }
                    else if (mouseDistance < -20)
                    {
                        swipeRight = true;
                        swipeLeft = false;
                    }
                    lastPosition = newPosition;
                }
            }
        }
     }
  }
