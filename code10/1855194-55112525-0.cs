    public GameObject dummyrotate;
    private bool rotate = false;
    float rotationAmount = .3f;
    float delaySpeed = .1f;
    
    
    void Update()
    {
        SlowSpin2();
    }
    
    public void SlowSpin2()
    
    {
        if (rotate == true) {
            dummyrotate.transform.Rotate(new Vector3(0,-rotationAmount,0));
            count += rotationAmount;
        }
    }
