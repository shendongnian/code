    public static class TestClass
    {
        public static void TestMethod(IService service)
        {
            //var someObject = new SomeObject(service, 5f);
            var someObject = new SomeObject(service).Load(5f);
        }
    }
