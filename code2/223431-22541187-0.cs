    [ConfigurationProperty("method", IsRequired = true)]
    public string MethodString
    {
      get { return (string)this["method"]; }
      set { this["method"] = value; }
    }
    public Method? Method
    {
      get { return (MethodString.Trim() == "*") ? null : (Method?)Enum.Parse(typeof(Method), MethodString.Trim(), true); }
      set { MethodString = (value == null) ? "*" : value.ToString(); }
    }
