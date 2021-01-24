    public Image image;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) WheelClicker();
    }
    public void WheelClicker()
    {
        // always prevent concurrent animations
        if(DOTween.IsTweening(transform)) return;        
        image.transform.DORotate(image.transform.eulerAngles + new Vector3(0, 0, 90), 1);
    }
    
