     public sealed class ImmutableFoo
        {
            private ImmutableFoo()
        {
                
        }
        public string SomeValue { get; set; }
        //more properties go here
        public sealed class Builder
        {
            private readonly ImmutableFoo _instanceFoo = new ImmutableFoo();
            public Builder SetSomeValue(string someValue)
            {
                _instanceFoo.SomeValue = someValue;
                return this;
            }
            /// Set more properties go here
            /// 
            public ImmutableFoo Build()
            {
                return _instanceFoo;
            }
        }
    }
