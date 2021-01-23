    using System;
    
    class OuterType
    {
        private static OuterType _instance;
    
        public OuterType()
        {
            _instance = this;
        }
    
        private String Message
        {
            get { return "Hello from OuterType"; }
        }
    
        public void testInnerType()
        {
            InnerType innerType = new InnerType();
            Console.WriteLine(innerType.FormattedOutertMessage);
        }
    
        private class InnerType
        {
            private readonly OuterType _outerType = _instance;
    
            public String FormattedOutertMessage
            {
                get { return _outerType.Message.ToUpper(); }
            }
            // InnerType doesn't need to dispose any object of OuterType.
        }
    }
