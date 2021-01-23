    using System;
    using System.Runtime.CompilerServices;
    class Foo
    {
        [MethodImplAttribute(MethodImplOptions.ForwardRef)]
        static extern void Frob();
        static void Main()
        {
            Frob();
        }
    }
