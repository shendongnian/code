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
    
        public abstract T Load();
    }
    
    public class OracleCustomerRepository : CustomerRepository<Customer>
    {
        public override Customer Load(){
            return new Customer();
        }
    }
