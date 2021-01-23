    private object lockObject1 = new object();
    private object lockObject2 = new object();
    public void foo()
    {      
        lock (lockObject1)
        {
             // ...
        }
    }
    public void bar()
    {      
        lock (lockObject2)
        {
             // ...
        }
    }
