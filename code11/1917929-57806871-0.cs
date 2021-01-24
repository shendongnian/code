    private bool rotating;
    private Camera cam;
    void Start()
    {
        holding = false;
        rotating = false;
        cam = Camera.main;
    }
    void Update()
    {
        // One finger
        if (Input.touchCount == 1)
        {
            Touch touch0 = Input.GetTouch(0);
            if (touch0.phase == TouchPhase.Began)
            {
                Ray ray;
                RaycastHit hitTouch;
                // test hold start
                ray = cam.ScreenPointToRay(touch0.position);
                if (Physics.Raycast(ray, out hitTouch, 100f))
                {
                    if (hitTouch.transform == transform)
                    {
                        holding = true;
                    }
                }
                else  // avoid rotating/raycasting again in situation 
                      // where this object may be in center of screen 
                      // but this or other object was touched.
                {
                    // test rotate start
                    ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                    if (Physics.Raycast(ray, out hitTouch, 100f)))
                    {
                        if (hitTouch.transform == transform)
                        {
                            rotating = true;
                        }
                    }
                } 
            }
            else if (touch0.phase == TouchPhase.Moved)
            {
                if (holding)
                {
                    Move();
                }
                else if (rotating)
                {
                    transform.Rotate(0f, touch0.deltaPosition.x * 0.5f, 0f);
                }
            }
            // Release
            else if (touch0.phase == TouchPhase.Ended)
            {
                holding = false;
                rotating = false;
            }
        }
    }
