    public float slowdownFactor = 0.05f;
    public float slowdownLength = 4f;
    private void Update()
    {
        SetTimeScale(Time.timeScale + (1f / slowdownLength) * Time.unscaledDeltaTime);
    }
    
    private void SetTimeScale(float scale)
    {
        Time.timeScale = Mathf.Clamp(scale, 0f, 1f);;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
    
    public void DoSlowMotion()
    {
        SetTimeScale(slowdownFactor);
    }
    
