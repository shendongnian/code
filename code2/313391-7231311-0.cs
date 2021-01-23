        public abstract class ProductTypePropertyBase<TValue>
        {
            public string Name { get; set; }
            public TValue Value { get; set; }
    
            protected ProductTypePropertyBase(string name, TValue value)
            {
                Name = name;
                Value = value;
            }
        }
