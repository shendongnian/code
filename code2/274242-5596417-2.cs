    public class AccessHelper<T>
    {
        internal T Value { get; set; }
    }
    public class AClass
    {
        public AClass()
        {
            InternalProperty.Value = "Can't get or set this unless you're a derived class inside this assembly.";
        }
        protected AccessHelper<String> InternalProperty
        {
            get;
            set;
        }
    }
