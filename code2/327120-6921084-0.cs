    class TestAttribute : Attribute
    {
        public int MyProperty { get; set; }
    }
    class Program
    {
        [Test(MyProperty=300)]
        public void method1()
        {
        }
    }
