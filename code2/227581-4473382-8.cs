    interface IRepository { bool CanAdd(string country); }
    class MyService : IService
    {
      private IRepository _service; private List<string> _countries;
      public IEnumerable<string> Countries { get { return _countries; } }
      public X(IRepository service) { _service = service; _countries = new List<string>(); }
      void AddCountry(string x) 
      {  
         if(_service.CanAdd(x)) {
            _conntires.Add(x);
         }
      }      
    }
