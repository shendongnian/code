    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        [StructLayout(LayoutKind.Sequential)]
        struct test
        {
            public uint foo;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                test soVar;
                soVar = new test { foo = 0x10007 };
            }
        }
    }
