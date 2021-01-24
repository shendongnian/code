    public class UnitOfWork : IUnitOfWork {
        private readonly IDataAccessContext _context;
        private ICustomerRepository _customerRepository;
        public UnitOfWork(IDataAccessContext context) {
            _context = context;
        }
        //...omitted for brevity
        
        
