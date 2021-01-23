    class Customer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        // approach here
        public string GetPropertyValue(string propertyName)
        {
            try
            {
                return this.GetType().GetProperty(propertyName).GetValue(this, null) as string;
            }
            catch { return null; }
        }
    }
    //use sample
    static void Main(string[] args)
        {
            var customer = new Customer { CustomerName = "Harvey Triana", Address = "Something..." };
            Console.WriteLine(customer.GetPropertyValue("CustomerName"));
        }
