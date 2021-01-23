    // Not actually valid C#!
    public string Name
    {
        // Only accessible within the property
        string name;
        get { return name; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            name = value;
        }
    }
