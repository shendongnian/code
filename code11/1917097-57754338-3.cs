       protected override void Seed(WebApplication1.CustomerContext context)
        {
            IList<Customer> customers = new List<Customer>
            {
                new Customer { id = 1, Name = "Jojo", IsSubscribedToNewsletter = true },
                   new Customer { id = 2, Name = "Jojo", IsSubscribedToNewsletter = true }
            };
            context.Customers.AddRange(customers);
            base.Seed(context);
        }
   
