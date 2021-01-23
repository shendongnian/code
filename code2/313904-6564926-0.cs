    using System;
    
    namespace ConsoleApplication1
    {
        public delegate void FunctionToBeCalled();
        public class A
        {
            public FunctionToBeCalled Function;
    
            public void Test()
            {
                Function();
                Console.WriteLine("test 2");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                A instanceA = new A();
                instanceA.Function = TheFunction;
                instanceA.Test();
            }
    
            static void TheFunction()
            {
                Console.WriteLine("test 1");
            }
        }       
    }
