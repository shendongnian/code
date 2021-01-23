    using System;
    using System.Text;
    
    class Test
    {
        public static void Main()
        {
            StringBuilder ref1 = new StringBuilder ("object1");
            Console.WriteLine (ref1);
            // The StringBuilder referenced by ref1 is now eligible for GC.
            StringBuilder ref2 = new StringBuilder ("object2");
            StringBuilder ref3 = ref2;
            // The StringBuilder referenced by ref2 is NOT yet eligible for GC.
            Console.WriteLine (ref3); // object2
        }
    }    
