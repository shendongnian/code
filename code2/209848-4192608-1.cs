    namespace MyNamespace
    {
        public class Customer
        {
            public string Name { get; set; }
        }
    
        public class CustomerManager
        {
            public List<Customer> GetCustomers()
            {
                List<Customer> cust = new List<Customer>();
                Customer c = new Customer();
                c.Name = "sampleName";
                cust.Add(c);
                return cust;
            }
        }
    }
