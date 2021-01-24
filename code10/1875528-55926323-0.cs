    public class CustomerNameEqualityComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer x, Customer y)
        {
            return string.Equals(x?.Name, y?.Name, StringComparison.OrdinalIgnoreCase);
        }
        public int GetHashCode(Customer obj)
        {
            return obj.Name?.GetHashCode() ?? 0;
        }
    }
