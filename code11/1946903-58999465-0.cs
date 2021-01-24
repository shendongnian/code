    public class Customer : CustomerBase
    {
     public Customer()
        {
            // SNIP
        }
        public Customer(string customerId)
        {
            CustomerId = customerId;
        }
        public string CustomerId { get; private set; }
        public string CustomerName { get; set; }
     }
    }
