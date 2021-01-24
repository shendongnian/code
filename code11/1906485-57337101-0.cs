    public class CustomersController : ODataController
    {
        private SI24 db = new SI24();
    
        // GET: api/Customers
        [EnableQuery(MaxExpansionDepth = 50)]
        public IQueryable<Customer> GetCustomers()
        {
            return db.Customers;
        }
    }
