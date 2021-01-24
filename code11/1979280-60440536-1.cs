    private MyTestObject _myBindToTestObject;
    
    public MyTestObject MyBindToTestObject
    {
       get { return _myBindToTestObject; }
       set 
       { 
           _myBindToTestObject = value; 
           NotifyOfPropertyChange(() => MyTestObject);
       }
    }
