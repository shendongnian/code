    [Produces("application/json")]
    public class CustomersController : ODataController
    {
        private readonly MyDbContext _context;
     
        public CustomersController (MyDbContext context) => _context = context;
     
        [EnableQuery]
        public IQueryable<Customer> GetAllCustomers() => _context.Customers;
    }
