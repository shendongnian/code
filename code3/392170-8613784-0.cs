    // By setting this as 'virtual' you can allow classes that inherit from this to override the functionality if they so wish
    public virtual string Name
    {
        get { return "SomeName"; }
    }
    // or
    public virtual string GetName()
    {
        return "SomeName";
    }
