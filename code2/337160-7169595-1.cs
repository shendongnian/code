    public int this[string key]
    {
        get { return _items[key]; }
        set 
        { 
            _items[key] = value; 
            PropertyInfo prop = this.GetType().GetProperty(key);
            if (prop != null)
            {
                prop.SetValue(this, null);
            }
        }
    }
