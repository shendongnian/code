    public class ExternalClass
    {
        private InternalClass _internalObject = new InternalClass();
        public event InternalClass.someDelegate SomeEvent
        {
            add
            {
                _internalObject.SomeEvent += value;
            }
            remove
            {
                _internalObject.SomeEvent -= value;
            }
        }
    }
    public class InternalClass
    {
        public delegate void someDelegate(string input);
        public event someDelegate SomeEvent;
    }
