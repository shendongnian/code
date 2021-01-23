    public class CrmServiceWrapper : ICrmService
    {
        private bool _disposed;
        private readonly CrmService _service;
        public CrmServiceWrapper(CrmService service)
        {
            _service = service;
        }
        public Guid Create(BusinessEntity entity)
        {
            return _service.Create(entity);            
        }
        
        ...
    }
