    public class SomeObjectFactory : ISomeObjectFactory
    {
        private IYourService _service;
        public SomeObjectFactory(IYourService service) 
        {
            _service = service;
        }
        public ISomeObject Create(float someValue)
        {
            return new SomeObject(_service, someValue);
        }
    }
