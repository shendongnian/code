    void LateUpdate () 
    {
        // Skip mouse input here if middle mouse button is not pressed
        if (Input.GetMouseButton(2))  
        { 
            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            y = ClampAngle(y, yMinLimit, yMaxLimit);
        }
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*5, distanceMin, distanceMax);
        Ray screenRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f, 0f));` 
        RaycastHit hitInfo;
        Physics.Raycast(screenRay, out hitInfo, Mathf.Infinity, groundLayerMask.value);
    
        Vector3 orbitPosition = hitInfo.point;
            
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + orbitPosition ;
        transform.rotation = rotation;
        transform.position = position;
    }
