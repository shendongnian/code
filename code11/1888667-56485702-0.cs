lang-csharp
    public MyObj testVar2
    {
        get { return _testVar2; }
        set
        {
            if (_testVar2 != value)
            {
               _testVar2 = value;
               RunSomeCode();
            }                
        }
    }
