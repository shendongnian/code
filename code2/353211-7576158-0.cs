    public class A
    {
        private SomeCommonObject theCommonObject;
        public event EventHandler CommonEvent
        {
            add { theCommonObject.CommonEvent += value; }
            remove { theCommonObject.CommonEvent -= value; }
        }
        public A()
        {
            theCommonObject = new SomeCommonObject();
        }
    }
