    #pragma warning disable 0612
    using System;
    
    namespace ConsoleApplication1
    {
        class Class1
        {
            [Obsolete()]
            public void Test()
            {
                 // the 'raw' method
            }
    
            private void CallTest()
            {
                Test(); // call the raw method without a compiler warning
            }
        }
    }
