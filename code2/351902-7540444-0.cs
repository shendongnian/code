        public class ExternalClass
    {
        private InternalClass _internalObject = new InternalClass();
        public event InternalClass.someDelegate OnEvent
        {
            add
            {
                _internalObject.OnEvent += value;
            }
            remove
            {
                _internalObject.OnEvent -= value;
            }
        }
    }
    public class InternalClass
    {
        public delegate void someDelegate(string input);
        public event someDelegate OnEvent;
    }
