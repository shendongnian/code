    void OnSceneGUI()
    {
        if (Event.current.type == EventType.MouseDown && Event.current.button == 1 && cancel)
        {
            cancel = false;
    
            var pointer = new PointerEventData(EventSystem.current);
             pointer.position = Input.mousePosition;
    
             List<RaycastResult> raycastResults = new List<RaycastResult>();
             EventSystem.current.RaycastAll(pointer, raycastResults);
    
             if(raycastResults.Count > 0)
             {
                 var obj = raycastResults[0].gameObject;
         
                ExecuteEvents.Execute<IPointerUpHandler>(obj, pointer, ExecuteEvents.pointerUpHandler);
                slider = 0;
            }
        }
    }
