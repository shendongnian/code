    private Camera mainCam;
    
    void Start()
    {
        mainCam = Camera.main;
    }
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 blockPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    
            Instantiate(block, blockPos, 0f), Quaternion.identity);
        }
    }
