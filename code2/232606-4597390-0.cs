    public class EntityContainer : ObjectContext
    {
        private IObjectSet<Customer> _customers;
        public IObjectSet<Customer> Customers
        {
            get
            {
                return _customers ?? 
                    ( _customers = CreateObjectSet<Customer>("Customers");
            }
        }
    }
    public class CustomerRepository
    {
        EntityContext _context = new EntityContext();
 
        public IQueryable<Customer> FindAll()
        { 
            return _context.Customers;
        }
        public Customer FindById(int id)
        {
            return _context.Customers.Single(c => c.Id == id);
        }
        // And so on.
    }
