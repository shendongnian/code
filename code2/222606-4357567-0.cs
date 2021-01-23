    public class MyClass
    {
        private static MyClass singletonInstance;
        public static MyClass SingletonInstance
        {
            get
            {
                if (singletonInstance == null)
                {
                    singletonInstance = new MyClass();
                }
                return singletonInstance;
            }
        }
        // the rest of your class implementation
    }
