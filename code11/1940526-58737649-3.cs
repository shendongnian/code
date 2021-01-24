        public static void TestGeneric<T>(T myParam) { }
        public static void Example()
        {
            string testString = null;
            int testInt = 0;
            TestGeneric(testString);
            TestGeneric(testInt);
        }
