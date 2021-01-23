    public Child this[string name]
    {
        get
        {
            return Children.Where(c => c.Name == name);
        }
    }
