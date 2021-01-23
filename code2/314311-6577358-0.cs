    namespace Example
    {
        public class MyTestClass
        {
            [MyAttribute]
        #if WINDOWS_PHONE
            internal void MyMethod()
        #else
            protected void MyMethod()
        #endif
            {
            }
        }
    }
