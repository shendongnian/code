    public class MyClass
    {
        private Action<string> _dataBridgeAppend;
        public MyClass(Action<string> dataBridgeAppend)
        {
            _dataBridgeAppend = dataBridgeAppend;
        }
    
        public void DoStuff()
        {
            // stuff
            _dataBridgeAppend("result"); // using the callback delegate to return stuff to the Form
        }
    }
