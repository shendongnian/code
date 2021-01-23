    public A()
    {
        Type childType = GetType();
        string className = childType.Name;
        if (!_DerivedPropertyNames.ContainsKey(className)) {
             // add properties for this class
        }
    }
