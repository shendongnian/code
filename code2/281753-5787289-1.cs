    public class DalFactory : IDalFactory
    {
        private IXXXRepository _xxxRepository;
        public IXXXRepository XXXRepository
        {
            return _xxxRepository ?? (_xxxRepository = new XXXRepository());
        }
    
        private IYYYRepository _yyyRepository;
        public IYYYRepository YYYRepository
        {
            return _yyyRepository ?? (_yyyRepository = new YYYRepository());
        }
    }
