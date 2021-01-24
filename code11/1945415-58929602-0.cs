    public abstract class CustomerRepository<T>
    {
        protected bool EnsureIsConnected()
        {
            return true;
        }
    
        public abstract T LoadCustomer();
    }
    
    public class OracleCustomerRepository : CustomerRepository<Customer>
    {
        private OracleConnection oracleConnection;
    
        public OracleCustomerRepository() : base(){
            if(base.EnsureIsConnected()){
                 // ...
            }
        }
    
        public override Customer LoadCustomer(){
            return new Customer();
        }
    }
