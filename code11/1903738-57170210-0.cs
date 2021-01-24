    Vector3 dist;
    Vector3 startPos;
    Vector3 startIntersect;
  
    bool clickedOnGround = false;
    void OnMouseDown()
    {
        clickedOnGround = false;
        startPos = transform.position;
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.down, new Vector3(0f, 4.8f, 0f)); 
        
        float planeHitDist;
        if (groundPlane.Raycast(cameraRay, out planeHitDist))  
        {
            clickedOnGround = true;
      
            startIntersect = cameraRay.GetPoint(planeHitDist);
        }
    }
    void OnMouseDrag()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.down, new Vector3(0f, 4.8f, 0f)); 
        float planeHitDist;
        if (groundPlane.Raycast(cameraRay, out planeHitDist))  
        {
            Vector3 newIntersect = cameraRay.GetPoint(planeHitDist);
            transform.position = startPos + (newIntersect - startIntersect);
        }
    }
