        //When mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            //If the mouse moves after clicking
            if (Input.GetAxis("Mouse X") < 0 || (Input.GetAxis("Mouse X") > 0))
            {
                //Do nothing
            }
            else {
                //If no movement is detected, then send ray to object and trigger event
                RaycastHit hit;
                //Create a ray that projects at the position of the clicked mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //If the ray hits the target object
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    //Load the scene that corresponds to the clicked object
                    LoadScene(hit.transform.gameObject);
                }
            }
               
        }
    }
