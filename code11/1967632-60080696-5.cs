    public static class Test2
    {
        public static void X()
        {
            var env1 = new ClassAWithMyExtensionMethods();
            var env2 = new ClassBWithMyExtensionMethods();
            var res1 = Test.UseMethod(100, 200)(env1);
            var res2 = Test.UseMethod(100, 200)(env2);
        }
    }
