    public class Customer
    {
        public string CustomerNumber { get; set; }
        // other properties
    
        public List<Account> Accounts { get; private set; }  // collection property
    
        public Customer()  // default constructor
        {
             Accounts = new List<Account>();
    
        }
    
    }
