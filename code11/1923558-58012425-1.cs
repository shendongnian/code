    private Camera mainCam;
  
    Start() 
    {
        // Camera.main calls FindGameObjectsWithTag internally, which is a costly operation.
        // It's best to cache the results of Camera.main when possible to save on computation.
        mainCam = Camera.main;
    }
  
    Update()
    {
        var delta = new Vector2(Input.GetAxisRaw("Horizontal"), 
                Input.GetAxisRaw("Vertical")).normalized * Time.deltaTime * moveSpeed;
        Vector3 minPos = mainCam.ViewportToWorldPoint(new Vector3(0,0,0));
        Vector3 maxPos = mainCam.ViewportToWorldPoint(new Vector3(1,1,0));
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x + delta.x, minPos.x, maxPos.x),
        Mathf.Clamp(transform.position.y + delta.y, minPos.y, maxPos.y),
        transform.position.z);
    }
