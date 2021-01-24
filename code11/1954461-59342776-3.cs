    private readonly object _myLock = new object();
    
    public void MyLockedMethod1()
    {
    	lock(_myLock)
    	{
    		MyLockedMethod2();
    	}
    }
    
    public void MyLockedMethod2()
    {
    	lock(_myLock)
    	{
    		//...
    	}
    }
