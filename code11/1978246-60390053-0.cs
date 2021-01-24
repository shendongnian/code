    // adjust via the Inspector as well
    [Tooltip("Color changes per second")]
    [SerializeField] private float blinkFrequency = 2f;
    private float timer;
    
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = 1 / blinkFrequency;
    
            blinkObject = !blinkObject;
            foreach (var child in rend_ThisObject)
            {
                child.material = blinkObject ? white : red;
            }
        }
    }
