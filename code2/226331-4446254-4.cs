    public partial class Customer
    {
        public static partial class Specification
        {
            public static Expression<Func<Customer, bool>> HasFunds(decimal amount)
            {
                return c => c.AvailableFunds >= amount;
            }
            public static Expression<Func<Customer, bool>> AccountAgedAtLeast(TimeSpan age)
            {
                return c => c.AccountOpenDateTime <= DateTime.UtcNow - age;
            }
            public static Expression<Func<Customer, bool>> LocatedInState(string state)
            {
                return c => c.Address.State == state;
            }
        }
    }
