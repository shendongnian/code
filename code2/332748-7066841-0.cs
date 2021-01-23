    public class MyPublicClass
    {
        public MyPrivateClass CreateClass()
        {
             return MyPrivateClass.GetInstance();
        }
    }
    public class MyPrivateClass
    {
        internal static MyPrivateClass GetInstance() { return new MyPrivateClass(); }        
        protected MyPrivateClass() { }
    }
