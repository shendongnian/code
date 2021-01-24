    public IEnumerator Function1(Action callback)
    {
        // do some stuff
        yield return new WaitForSeconds(1);
        // do some stuff
        callback.Invoke();
    }
    
    public IEnumerator Function2(Action callback)
    {
        // do some stuff
        yield return new WaitForSeconds(1);
        // do some stuff
        callback.Invoke();
    }
    
    public void CallingMethod()
    {
        StartCoroutine(Function1(() => 
        {
            StartCoroutine(Function2(() =>
            {
                // whatever other code you want executed
            }));
        }));
    }
