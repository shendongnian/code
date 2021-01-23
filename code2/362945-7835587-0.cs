    private readonly object objectLockA = new object();
    private readonly object objectLockB = new object();
    
    public void MethodA()
    {
        lock(objectLockA)
        {
        lock(objectLockB)
        {
           //...
        }
        }
    }
    
    public void MethodB()
    {
        lock(objectLockB)
        {
        lock(objectLockA)
        {
          //do something
        }
        }
    }
