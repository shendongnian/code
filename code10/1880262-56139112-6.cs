    cubePosition = Player.transform.position;
    if ((Input.GetKey(KeyCode.Mouse0) && cubeisClicked) && ((rb.velocity.x == 0f && rb.velocity.y == 0f)))
    {
        cubeisClicked2 = true;
        Plane cubePlane = new Plane(cam.transform.position - cubePosition, cubePosition);
        // reusing camRay
        // Determine if we are even hitting the plane
        float enter = 0.0f;
        if (cubePlane.Raycast(camRay, out enter))
        {
            fingerPosition  = camRay.GetPoint(enter);
