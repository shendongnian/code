    private void FixedUpdate()
    {
        deg += 1f;
    
        if (deg >= 360f) deg = 0;
    
    
        Vector3 cenLocal = go.transform.position; // center (local space)
        Vector3 cenGlobal = go.transform.TransformPoint(cenLocal); // center (global space)
    
        go.transform.RotateAround(cenGlobal , Vector3.up, deg);
    
    
    }
