     public Form1()
            {
                InitializeComponent();
                CustomerRepository myRepository = new CustomerRepository();
                myRepository.GetError("string error");
    
            }
            public interface IRepository
            {
                string GetError(string LogNumber);
            }
    
            public class Repository : IRepository
            {
                public Repository()
                {
                }
    
                public string GetError(string LogNumber)
                {
                    return "The error is " + LogNumber;
                }
            }
    
            public interface ICustomerRepository
            {
                // READ
                List<Customer> ReadAll();
    
            }
    
            public class CustomerRepository : Repository, ICustomerRepository
            {
                public CustomerRepository() : base()
                {
                }
    
    
                public List<Customer> ReadAll()
                {
                    List<Customer> list;
                    return list = new List<Customer>();
                }
            }
    
            public class Customer
            {
            }
  
