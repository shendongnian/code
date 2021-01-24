    public class SomeBaseClass
    {
        protected SomeBaseClass(string prop1)
        {
            SomeProperty = prop1;
        }
        public string SomeProperty { get; private set; }
    }
    public class SomeClass : SomeBaseClass
    {
        public SomeClass(string prop1, string prop2) : base(prop1)
        {
            OtherProperty = prop2;
        }
        public SomeClass(string prop1, int prop2) : base(prop1)
        {
            OtherProperty = prop2.ToString();
        }
        public string OtherProperty { get; private set; }
        public override string ToString() =>
            $"({SomeProperty}, {OtherProperty})";
    }
