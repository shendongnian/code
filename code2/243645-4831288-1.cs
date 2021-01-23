    public object this[string key]
    {
      get
      {
        var prop = typeof(ThisClassName).GetProperty(key);
        if (prop != null)
        {
          return prop.GetValue(this, null);
        }
        return null;
      }
      set
      {
        var prop = typeof(ThisClassName).GetProperty(key);
        if (prop != null)
        {
          prop.SetValue(this, value, null);
        }
      }
    }
