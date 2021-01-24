    public class A
    {
        public string Value1 { get; set; }
        public int Value2 { get; set; }
        public A()
        {
            Value1 = "First";
            Value2 = 2;
        }
    }
    public class B : A
    {
        public int Value3 { get; set; }
        // This line overriding Value1 from the parent class A, so you can now assign it to a boolean (or CustomClass) value
        public new bool Value1 { get; set; }
        public B()
        {
            Value3 = 3;
            // Value2 = new CustomClass(); //Error since Value2 is declared to integer in the parent class
            // What you can do is to assign Value2 to a new integer value
            Value2 = 8;
        }
    }
