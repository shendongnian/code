    public int Add(int x, int y)
    {
      var config = OperationContext.Current.Host.Extensions.Find<CustomConfigurer>();
      if (config == null)
      {
        // Load elsewhere
      }
    }
