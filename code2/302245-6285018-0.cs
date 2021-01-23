    namespace TestNamespace
    {
        using System;
        public static class TextExtension
        {
            public static void Print(this Test test)
            {
                Console.WriteLine("Found");
            }
        }
        public class Test
        {
            public void Foo()
            {
                // Compiler error!
                Print();
                // Works fine
                this.Print();
            }
        
            static void Main()
            {
                Test test = new Test();
                test.Foo();
                // Fine here
                test.Print();
                Console.ReadKey();
            }
        }
    }
