    public delegate void MyMessageHandlerType(string message);
    
    public class EventTest
    {
        public event MyMessageHandlerType MessageEvent
        {
            add { } // invoked when MessageEvent += SomeMethod
            remove { } // invoked when MessageEvent -= SomeMethod
        }
    }
