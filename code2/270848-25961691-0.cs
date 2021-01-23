    class Customer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        // approach here
        public string GetPropertyValue(string propertyName)
        {
            return this.GetType().GetProperties()
                  .Single(p => p.Name == propertyName)
                  .GetValue(this, null) as string;
        }
    }
    //use sample
    static void Main(string[] args)
        {
            var customer = new Customer { CustomerName = "Harvey Triana", Address = "Something..." };
            Console.WriteLine(customer.GetPropertyValue("CustomerName"));
        }
