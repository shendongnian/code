    public string Name
    {
        get
        {
            if (empty SubItems collection)
                return "";
            return SubItems[0].Name;
        }
        set
        {
            SubItems[0].Name = value;
        }
    }
