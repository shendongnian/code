    //child uc class
    ...
    public string MyValue { get; private set; }
    
    //... loaded (...)
    {
        ...
        this.MyValue = "Value";
    }
    // Parent uc class
    //... loaded (...)
    {
        ...
        string childValue = this.ucChildControl.MyValue;
    }
