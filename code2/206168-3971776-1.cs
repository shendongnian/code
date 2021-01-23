        static void Main(string[] args)
        {
            // presumably you will have a separate collection of all your Customer objects somewhere
            List<Customer> customers = new List<Customer>();
            Customer customer1 = new Customer { Id = 1, FullName = "Jo Bloogs" };
            Customer customer2 = new Customer { Id = 2, FullName = "Rob Smith" };
            Customer customer3 = new Customer { Id = 3, FullName = "Rob Zombie" };
            customers.Add(customer1);
            customers.Add(customer2);
            customers.Add(customer3);
            Dictionary<Customer, int> CustomerOrderDictionary = new Dictionary<Customer, int>();
            CustomerOrderDictionary.Add(customer1, 3);
            CustomerOrderDictionary.Add(customer2, 5);
            // let's just say that we're going to update the value for any customers whose name starts with "Rob"
            // use the separate list of Customer objects for the iteration,
            // because you would not be allowed to modify the dictionary if you iterate over the dictionary directly
            foreach (var customer in customers.Where(c => c.FullName.StartsWith("Rob")))
            {
                // the dictionary may or may not contain an entry for every Customer in the list, so use TryGetValue
                int value;
                if (CustomerOrderDictionary.TryGetValue(customer, out value))
                    // if an entry is found for this customer, then increment the value of that entry by 1
                    CustomerOrderDictionary[customer] = value + 1;
                else
                    // if there is no entry in the dictionary for this Customer, let's add one just for the heck of it
                    CustomerOrderDictionary.Add(customer, 1);
            }
        }
