    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    static class Program
    {
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int sprintf([Out] StringBuilder buf, string format, params object[] args);
    
        static void Main(string[] args)
        {
            Foo(2); //No error!
            Bar<int>(2); //Error: "The signature is incorrect"
        }
    
        static void Foo(int a) { sprintf(new StringBuilder(8), "%d", a); }
        static void Bar<T>(T a){ sprintf(new StringBuilder(8), "%d", a); }
    }
