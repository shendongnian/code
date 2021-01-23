    private int _Number = 10;
    
    [DefaultValue(10)]
    [Description("This is a number.")]
    public int Number
    {
      get { return _Number; }
      set { _Number = value; }
    }
