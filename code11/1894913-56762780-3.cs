    public float maxSpeed = 25f;
    public float speed = 0f;
    public float acceleration = 0.1f; // (0 to maxSpeed in 10 seconds)
    public float EaseInQuart(float t) {
        return Mathf.Pow(Mathf.Clamp01(t),4f);
    }
    public float InverseEaseInQuart(float x) {
        return Mathf.Pow(Mathf.Clamp01(x),0.25f);
    }
    void Update(){ 
        float x = speed / maxSpeed;
        
        float t = InverseEaseInQuart(x);
        
        t += Time.deltaTime * acceleration;
        x = EaseInQuart(t);
        speed = x * maxSpeed;
    }
     
