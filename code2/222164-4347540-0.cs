    public class CustomerEqualityComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer c1, Customer c2)
        {
            return c1.Id == c2.Id;
        }
        public int GetHashCode(Customer c)
        {
            return c.Id.GetHashCode();
        }
    }
