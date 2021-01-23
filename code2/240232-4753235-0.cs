    namespace ClassLibrary1
    {
        using System;
        public class Widget
        {
            public Widget()
            {
            }
            public void Foo()
            {
                throw new InternalException() ;
            }
        }
        
        namespace ClassLibrary1
        {
            internal class InternalException : Exception
            {
            }
        }
        
    }
