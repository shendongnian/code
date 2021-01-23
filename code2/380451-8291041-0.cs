    class TestAttribute : Attribute
    {
        public TestAttribute(object test = null) { }
        public void TestMethod(object test = null) { }
    }
    class TestClass
    {
        public TestClass(object test  = null) { }
    }
    [Test()] // crashes
    //[Test(null)] // works
    class Program
    {
        static void Main(string[] args)
        {
            TestClass t = new TestClass(); // works
            TestAttribute a = typeof(Program).GetCustomAttributes(typeof(TestAttribute), false).Cast<TestAttribute>().First();
            
            a.TestMethod(); // works
        }
    }
