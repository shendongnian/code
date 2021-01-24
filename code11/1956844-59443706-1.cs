    // Can only read status
    class MyClass1
    {
    	MyClass1(IReadOnlyStatus status)
    	{
    	
    	}
    }
    
    // Can read and update status
    class MyClass3
    {
    	MyClass3(IStatus status)
    	{
    	
    	}
    }
    
    class MainViewModel
    {
        Status status;
        public MainViewModel()
        {
            status = new Status();
            // The cast is not necessary but added for clarity
            MyClass1 object1 = new MyClass1((IReadOnlyStatus)status);
            MyClass3 object3 = new MyClass3((IStatus)status);
        }
    }
