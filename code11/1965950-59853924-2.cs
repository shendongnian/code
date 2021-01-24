    public class MyClass
    {
        private static MyClass _instance;
        private MyClass()
        {
            //Do Stuff
        }
        public static MyClass GetInstance()
        {
             if(_instance == null)
                 _instance = new MyClass();
             return _instance;
        }
    }
