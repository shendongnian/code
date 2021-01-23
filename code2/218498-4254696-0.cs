    public class MyEventArgs : EventArgs
    {
        private string m_Data;
        public MyEventArgs(string _myData)
        {
            m_Data = _myData;
        } // eo ctor
        public string Data {get{return m_Data} }
    } // eo class MyEventArgs
    public delegate void MyEventDelegate(MyEventArgs _args);
    public class MySource
    {
        public void SomeFunction(string _data)
        {
            // raise event
            if(OnMyEvent != null) // might not have handlers!
                OnMyEvent(new MyEventArgs(_data));
        } // eo SomeFunction
        public event MyEventDelegate OnMyEvent;
    } // eo class mySource
