    private MyObj testVar2;
    public MyObj TestVar2
    {
        get { return testVar2; }
        set
        {
            if (value == null) return;      // Or throw an ArgumentNullException
            if (testVar2 == value) return;  // No need to RunSomeCode if the value isn't changing
            testVar2 = value;
            RunSomeCode();                
        }
    }
