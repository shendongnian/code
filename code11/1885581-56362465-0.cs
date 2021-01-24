    private float _previousScale = 1;
    private IEnumerator Speedup()
    {
        yield return new WaitForSeconds(10f);
        Time.timeScale += 0.05f;
        StartCoroutine(Speedup());
    }
    public void pausegame()
    {
        _previousScale = Time.timeScale;
        Time.timeScale = 0;
    }
    
    public void unpausegame()
    {
        Time.timeScale =  _previousScale;
    }
