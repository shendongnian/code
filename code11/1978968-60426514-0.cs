    Coroutine zoom;
    float timer = 0f;
    public Camera main;
    public float zoomedOutValue = 110f;
    public float zoomedInValue = 100f;
    public float zoomOutDuration = 2f;
    public float zoomInDuration = 2f;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(zoom != null)
            {
                StopCoroutine(zoom);
            }
            zoom = StartCoroutine(ZoomCamera(zoomedInValue, (zoomInDuration - timer)));
        }
    
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if(zoom != null)
            {
                StopCoroutine(zoom);
            }
            zoom = StartCoroutine(ZoomCamera(zoomedOutValue, (zoomOutDuration - timer)));
        }
    
    }
    
    IEnumerator ZoomCamera(float newZoom, float duration)
    {
        float oldZoom = main.fieldOfView;
        timer = 0f;
        
        while(timer < duration)
            {
                 main.fieldOfView = Mathf.Lerp(oldZoom, newZoom, timer/duration);
                 timer -= Time.deltaTime;
                 yield return null;
            }
        main.fieldOfView = newZoom;
        timer = 0f;
    }
