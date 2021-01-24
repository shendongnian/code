    private float slidingH;
    private float slidingV;
    private void FixedUpdate()
    {
        float h = 0f;
        float v = 0f;
        Vector2 smoothedInput;
    
        if (inout.ToLower() == "w") 
        {
            v = 1f;
        }
        else if (inout.ToLower() == "s")
        {
            v = -1f;
        }
        else if (inout.ToLower() == "a")
        {
            h = -1f;
        }
        else if (inout.ToLower() == "d")
        {
            h = 1f;
        }
        
        smoothedInput = SmoothInput(h,v);
        float smoothedH = smoothedInput.x;
        float smoothedV = smoothedInput.y;
    }
    private Vector2 SmoothInput(float targetH, float targetV)
    {
        float sensitivity = 3f;
        float deadZone = 0.001f;
         
        slidingH = Mathf.MoveTowards(slidingH,
                      targetH, sensitivity * Time.deltaTime);
        slidingV = Mathf.MoveTowards(slidingV ,
                      targetV, sensitivity * Time.deltaTime);
        return new Vector2(
               (Mathf.Abs(slidingH) < deadZone) ? 0f : slidingH ,
               (Mathf.Abs(slidingV) < deadZone) ? 0f : slidingV );
    }
    .
