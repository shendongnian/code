    if(Input.touchSupported)
    {
        /* Implement touches */ 
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            // ...
        }
    } 
    // Optional
    else 
    { 
        /* alternative mouse implementation for development */
        if(Input.GetMouseButtonDown(0))
        {
            // simulates touch begin
        }
        else if(Input.GetMouseButton(0))
        {
            // simulates touch moved
        }
        // I've seen in strange occasions that down and up might get called within one frame
        if(Input.GetMouseButtonUp(0))
        {
            // simulates touch end
        }
    }
