     class Class1
    {
        public Class1(decimal value)
        {
            this.Value = value;
        }
        public decimal Value { get; }
    }
    class Class2
    {
        public Class2(decimal value)
        {
            this.Value = value;
        }
        public decimal Value { get; }
    }
    class Class3
    {
        private decimal value;
        public Class3(Class1 class1, Class2 class2)
        {
            this.value = class1.Value + class2.Value;
        }
    }
