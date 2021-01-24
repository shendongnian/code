    public abstract class CustomerRepository<T>
    {
        protected OracleConnection oracleConnection;
    
        protected CustomerRepository() : base(){
            if(EnsureIsConnected()){
                // ...
            }
        }
    
        protected bool EnsureIsConnected()
        {
            return true;
        }
    
        public abstract T LoadCustomer();
    }
    
    public class OracleCustomerRepository : CustomerRepository<Customer>
    {
        public override Customer LoadCustomer(){
            return new Customer();
        }
    }
