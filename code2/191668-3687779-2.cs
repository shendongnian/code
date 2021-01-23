    namespace COMTest
    {
        using System;
        using System.Runtime.InteropServices;
    
        public interface IFoo
        {
            void Bar();
        }
    
        [ComVisible(true)]
        public class Foo : IFoo
        {
            public void Bar()
            {
                Console.WriteLine("Bar");
            }
        }
    }
