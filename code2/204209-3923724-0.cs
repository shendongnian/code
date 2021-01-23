    static class TestClassExtension
    {
        public static bool IsThisOK(this TestClass, string str)
        {
            return true;
        }
    }
    class TestClass
    {
        public bool IsThisOK { get; set; }
        public static void Test()
        {
            TestClass c = new TestClass();
            c.IsThisOK = this.IsThisOK("Hello");
        }
    }
