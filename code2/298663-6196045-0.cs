    public string this[this key]
    {
        get { return dictionary[key]; }
        set { dictionary[key] = value == null ? null : value.Trim(); }
    }
