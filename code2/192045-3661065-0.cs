    public class SomeTest
    {
        public string Value { get; private set; }
        public string AnotherValue { get; set; }
        public string YetAnotherValue { get; set;}
        public SomeTest() { }
        public SomeTest(string value)
        {
            Value = value;
        }
    }
