    public class MyClass
    {
        private static MyClass instance;
        private MyClass()
        {
        }
        public static GetInstance()
        {
            if(instance == null)
                instance = new MyClass();
            return instance;
        }
    }
