    class X 
    {
      private IService _service;
      public X(IService service) { _service = service; }
      void DoSomething(string x) 
      {         
         _service.AddCountry(x.Trim()); // Trim() => example operation
      }
    }
