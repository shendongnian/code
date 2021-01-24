    public IEnumerator Drive(int x, int y)
    {
        // driving routine here.
    }
    
    public IEnumerator Rotate(float angle)
    {
        // rotation routine here.
    }
    
    public IEnumerator Stop()
    {
       // Stop routine here
    }
    
    public IEnumerator ExecuteAll()
    {
        // Drive
        yield return new StartCoroutine(Drive(30,5));
    
        // rotate
        yield return new StartCoroutine(Rotate(45));
    
        // Stop
        yield return new StartCoroutine(Stop());
     
     
        // All actions are done.
    }
    public void StartAll()
    {
       StartCoroutine(ExecuteAll());
    }
