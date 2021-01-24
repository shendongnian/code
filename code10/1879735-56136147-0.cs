    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class OrderAttribute : Attribute
    {
        public int Order { get; }
        public OrderAttribute(int order) => Order = order;
    }
