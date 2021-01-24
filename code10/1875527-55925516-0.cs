    public class CustomerNameEqualityComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer x, Customer y)
        {
            return string.Equals(x?.Name, y?.Name, StringComparison.CurrentCultureIgnoreCase);
        }
        public int GetHashCode(Customer obj)
        {
            return obj.Name?.GetHashCode() ?? 0;
        }
    }
