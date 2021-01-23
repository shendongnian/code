        static void Main(string[] args)
        {
            Dictionary<Customer, int> CustomerOrderDictionary = new Dictionary<Customer, int>();
            Customer customer1 = new Customer { Id = 1, FullName = "Jo Bloogs" };
            Customer customer2 = new Customer { Id = 2, FullName = "Rob Smith" };
            CustomerOrderDictionary.Add(customer1, 3);
            CustomerOrderDictionary.Add(customer2, 5);
            // you already have a reference to customer1, so just use the accessor on the dictionary to update the value
            CustomerOrderDictionary[customer1]++;
        }
