    public class AClass
    {
        public AClass()
        {
            InternalProperty.Value = "Can't get or set this in a derived class outside this assembly.";
        }
        protected class AccessHelper<T>
        {
            internal T Value { get; set; }
        }
        protected AccessHelper<String> InternalProperty
        {
            get;
            set;
        }
    }
