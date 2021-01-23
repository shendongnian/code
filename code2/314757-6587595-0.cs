    using System;
    
    class Program
    {
        delegate void Foo(ref int x, string y);
            
        static void SampleFoo(ref int x, string y)
        {
            Console.WriteLine("Incoming: {0}", x); // 10
            x = y.Length;
        }
        
        static void Main(string[] args)
        {
            int x = 0;
            int input = 10;
            Foo f = SampleFoo;
            IAsyncResult result = f.BeginInvoke(ref input, "Hello", null, null);
            f.EndInvoke(ref x, result);
            Console.WriteLine("Result: {0}", x); // 5
        }
    }
