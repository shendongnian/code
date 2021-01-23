    public static class MyTypeFactoryInitializer
    {
        private static bool isCalled;
        private static readonly Object lockObject = new object();
        public static void Initialize()
        {
            // double checking lock ensures that the code below only runs once throughout the application.
            if (!isCalled)
            {
                lock (lockObject)
                {
                    if (!isCalled)
                    {
                        MyTypeFactory<Type1>.Func = (a, b) => new Type1(a, b);
                        MyTypeFactory<Type2>.Func = (a, b) => new Type2(a, b);
                        isCalled = true;
                    }
                }
            }
        }
    }
