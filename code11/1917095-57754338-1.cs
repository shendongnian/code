    public class CustomerDBInitializer : DropCreateDatabaseAlways<CustomerContext>
        {
            protected override void Seed(CustomerContext context)
            {
                IList<Customer> customers = new List<Customer>
                {
                    new Customer { id = 1, Name = "Jojo", IsSubscribedToNewsletter = true }
                };
        
                context.Customers.AddRange(customers);
        
                base.Seed(context);
            }
        }
