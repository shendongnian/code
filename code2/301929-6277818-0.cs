        static void Main(string[] args)
        {
            var firstCustomers = new[] { new Customer { Id = 1, Name = "Bob" }, new Customer { Id = 2, Name = "Steve" } };
            var secondCustomers = new[] { new Customer { Id = 2, Name = "Steve" }, new Customer { Id = 3, Name = "John" } };
            var customers = secondCustomers.Where(c => !firstCustomers.Select(fc => fc.Id).Contains(c.Id));
        }
        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
