    public virtual string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value == "Status")
                DoSomeNoOp(); // breakpoint here, or Debug.Fail() inside your no-op
            
            _name = value;
        }
    }
