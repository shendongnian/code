    public object LockedObject1 = new Object();
    public object LockedObject2 = new Object();
    
    public void MyFunction(object arg)
    {
        WaitCallback pFunc = delegate
        {
            // Operations on locked objects
        }
        
        MultiLock(new object[] {LockedObject1, LockedObject2}, pFunc);
    }
