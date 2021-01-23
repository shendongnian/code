    using System;
    using System.Runtime.CompilerServices;
    class Foo
    {
        // Need to declare extern constructor because C# would inject one and break things.
        [MethodImplAttribute(MethodImplOptions.ForwardRef)]
        public extern Foo();
        [MethodImplAttribute(MethodImplOptions.ForwardRef)]
        static extern void Main();
        static void Frob()
        {
            Console.WriteLine("Hello!");
        }
    }
