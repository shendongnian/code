    public string Name
    {
       get { return _name; }
       set { SomeSimpleNotifyMethod(ref _name, value, this, "Name"; }
    }
