    Vector3 prevFingerPosition = Vector3.zero;
    Vector3 GetFingerPressInWorldSpace() 
    {
        Plane dragPlane = new Plane(Camera.main.transform.forward, transform.position);
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;
        if (dragPlane.Raycast(camRay, out enter))
        {
            return camRay.GetPoint(enter);
        }
        return prevFingerPosition;
    }
    void OnMouseDown()
    {
        prevFingerPosition = GetFingerPressInWorldSpace();
    }
    void OnMouseDrag()
    {
        Vector3 fingerPosition = GetFingerPressInWorldSpace();
        transform.Translate(fingerPosition-prevFingerPosition);
        prevFingerPosition = fingerPosition;
    }
