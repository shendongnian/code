    class Test
    {
        [Order(1)] public bool First { get; set; }
        [Order(2)] public int Second;
        [Order(3)] public string Third { get; set; }
    }
    ...
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, 
        Inherited = true, AllowMultiple = false)]
    [ImmutableObject(true)]
    public sealed class OrderAttribute : Attribute {
        private readonly int order;
        public int Order { get { return order; } }
        public OrderAttribute(int order) {this.order = order;}
    }
