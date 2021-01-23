     class TestClass
    {
        public bool IsThisOK { get; set; }
        public static bool isThisOK(string str)
        {
            return true;
        }
        public static void Test()
        {
            TestClass c = new TestClass();
            c.IsThisOK = isThisOK("Hello");
        }
}
