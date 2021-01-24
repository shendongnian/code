    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Serialization;
    public class PlayerActionHandler : MonoBehaviour
    {
    private Camera _cam;
    public bool beingDragged;
    public Vector3 offset;
    public Vector3 currPos;
    public int fingerIndex;
    public GameObject otherObj;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        //ONLY WORKS FOR 2 OBJECTS
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var raycast = _cam.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(raycast, out hit))
            {
                //use this tag if you want only chosen objects to be draggable 
                if (hit.transform.CompareTag("Draggable"))
                {
                    if(hit.transform.name == name)
                    {
                        //set being dragged and finger index so we can move the object 
                        beingDragged = true;
                        offset = gameObject.transform.position - _cam.ScreenToWorldPoint(Input.GetTouch(0).position);
                        offset = new Vector3(offset.x, offset.y, 0);
                        fingerIndex = 0;
                    }
                }
            }
        }else if (Input.touchCount == 1 && beingDragged)
        {
            otherObj.transform.SetParent(transform);
            if (Input.GetTouch(fingerIndex).phase == TouchPhase.Moved ){
                Vector3 pos = _cam.ScreenToWorldPoint(Input.GetTouch(fingerIndex).position);
                currPos = new Vector3(pos.x, pos.y,0) + offset;
                transform.position = currPos;
                       
            }
        }
        //ONLY WORKS FOR 2 OBJECTS_END
        else if (beingDragged && Input.touchCount > 1)
         {
             //We tie each finger to an object so the object only moves when tied finger moves
             if (Input.GetTouch(fingerIndex).phase == TouchPhase.Moved ){
                 Vector3 pos = _cam.ScreenToWorldPoint(Input.GetTouch(fingerIndex).position);
                 currPos = new Vector3(pos.x, pos.y,0) + offset;
                 transform.position = currPos;
                       
             }
         }else if (Input.touchCount > 0)
           {
               for (var i = 0; i < Input.touchCount; i++)
               {
                   //We find the fingers which just touched the screen
                   if(Input.GetTouch(i).phase == TouchPhase.Began)
                   {
                       var raycast = _cam.ScreenPointToRay(Input.GetTouch(i).position);
                       RaycastHit hit;
                       if (Physics.Raycast(raycast, out hit))
                       {
                           //use this tag if you want only chosen objects to be draggable 
                           if (hit.transform.CompareTag("Draggable"))
                           {
                               if(hit.transform.name == name)
                               {
                                   //set being dragged and finger index so we can move the object 
                                   beingDragged = true;
                                   offset = gameObject.transform.position - _cam.ScreenToWorldPoint(Input.GetTouch(i).position);
                                   offset = new Vector3(offset.x, offset.y, 0);
                                   fingerIndex = i;
                               }
                           }
                       }
                   }
               }
           }else if (Input.touchCount == 0)
           {
               //if all fingers are lifted no object is being dragged
               beingDragged = false;
           }
    }
