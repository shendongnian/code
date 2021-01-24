    using System;
    using System.Runtime.InteropServices;
    
    namespace test
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello");
                GoFunctions.Test("world");
                Console.WriteLine("Goodbye.");
            }
        }
    
    
        static class GoFunctions
        {
        [DllImport(@<path to test.dll>, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void Test(byte[] str);
        }
    }
