    if (Input.GetMouseButtonDown(0))
         {
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hitInfo;
             if (Physics.Raycast(ray, out hitInfo))
             {
                 if (hitInfo.collider.gameObject.tag == "Wall")
                 {
                     Debug.Log("tag");
                     //You can do what ever you want here.
                 }
             }
         }
