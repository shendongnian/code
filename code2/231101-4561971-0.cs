    public class MyClass { ... }
    public class MyRepository
    {
        public MyClass GetMyClassInstance(...);
    }
    public static class MyClassFactory
    {
        public static MyClass SingletonInstance 
        { 
            get 
            { 
                if (singletonInstance == null) 
                    singletonInstance = myRepository.GetMyClassInstance(...);
                return singletonInstance;
            }
        }
    }
