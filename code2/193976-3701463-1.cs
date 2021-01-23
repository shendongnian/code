    public abstract class AbstractCustomerRepository<T> : ICustomerRepository where T : class, ICustomer
    {
        public ICustomer Retrieve(int id)
        {
            return _session.Get<T>(id);
        }
    }
    public class CustomerRepository : AbstractCustomerRepository<Customer>
    {
        
    }
