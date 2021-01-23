    public object this[string key]
    {
      var prop = typeof(ThisClassName).GetProperty(key);
      if (prop != null)
      {
        return prop.GetValue(this, null);
      }
      return null;
    }
