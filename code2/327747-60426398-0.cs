    interface ISomeParameters
    {
      public float SomeValue { get; set; }
    }
    
    class SomeParameters : ISomeParameters
    {
     public float SomeValue{ get; set; } = 42.0;
    }
    
    services.AddSingleton(ISomeParameters, SomeParameters)
    
    public MyService(IService service, ISomeParameters someParameters)
    {
      someParameters.SomeValue
     ...
