    struct FooEnum
    {
        private int value;
        private string name;
        private FooEnum(int value, string name)
        {
            this.name = name;
            this.value = value;
        }
        public static readonly FooEnum A = new FooEnum(0, "Foo A");
        public static readonly FooEnum B = new FooEnum(1, "Foo B");
        public static readonly FooEnum C = new FooEnum(2, "Foo C");
        public static readonly FooEnum D = new FooEnum(3, "Foo D");
        public override string ToString()
        {
            return this.name;
        }
        //TODO explicit conversion to int etc.
    }
