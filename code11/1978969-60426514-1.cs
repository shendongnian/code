    Coroutine zoom;
    float timer = 0f;
    public Camera main;
    public float zoomedOutValue = 110f;
    public float zoomedInValue = 100f;
    public float zoomDuration = 0.2f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(zoom != null)
            {
                StopCoroutine(zoom);
            }
            zoom = StartCoroutine(ZoomCamera());
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if(zoom != null)
            {
                StopCoroutine(zoom);
            }
            zoom = StartCoroutine(ZoomCamera(false));
        }
    }
    IEnumerator ZoomCamera(bool zoomIn = true)
    {
        if(zoomIn)
        {
            while(timer < zoomDuration)
                {
                    main.fieldOfView = Mathf.Lerp(zoomedOutValue, zoomedInValue, timer/zoomDuration);
                    timer += Time.deltaTime;
                    yield return null;
                }
            timer = zoomDuration;
            main.fieldOfView = zoomedInValue;
        }
        else
        {
            while(timer > 0f)
                {
                    main.fieldOfView = Mathf.Lerp(zoomedOutValue, zoomedInValue, timer/zoomDuration);
                    timer -= Time.deltaTime;
                    yield return null;
                }
            timer = 0;
            main.fieldOfView = zoomedOutValue;
        }
    }
