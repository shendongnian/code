    public class SomeAPI : ISomethingService
    {
        private ISomethingService Service { get; set; }
        public SomeAPI(ISomethingService service)
        {
            Service = service;
        }
    
        public IEnumerable<SomeDto> GetSome()
        {
            return Service.GetSome();
        }
    }
