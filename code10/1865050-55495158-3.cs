    public object this[string key]
    {
        get
        {
            var prop = GetType().GetProperty(key);
            return prop.GetValue(this);
        }      
        set
        {
            var prop = GetType().GetProperty(key);
            prop.SetValue(this, value);
        }
    }
