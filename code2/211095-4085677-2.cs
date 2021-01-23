    public static IQueryable<Customer> WhoAreValidByAge(this IQueryable<Customer> customers)
    {
        cusomters.Select(c => new { Customer = c, Age = (DateTime.Today.Year - c.BirthDate.Year) }
                 .Where(c => (c.Age > 20 && c.Customer.AccountType == "Savings")
                          || (c.Age > 40 && c.Customer.AccountType == "Current"))
                 .Select(c => c.Customer)
    }
