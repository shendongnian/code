    Vector3 prevFingerPosition = Vector3.zero;
    // Same code as before but we use it in different places so it goes in its own method.
    private Vector3 GetFingerPressInWorldSpace() 
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
