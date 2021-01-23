    using (FooDbContext context = new FooDbContext("theSchemaName"))
    {
        foreach (
            var customer in context.Customers
                    .Include(c => c.City)
                .Where(c => c.CustomerName.StartsWith("AA"))
                .OrderBy(c => c.CustomerCode)
            )
        {
            Console.WriteLine(string.Format(
                "{0:20}: {1} - {2}, {3}",
                customer.CustomerCode,
                customer.CustomerName,
                customer.City.CityName,
                customer.City.State));
        }
    }
