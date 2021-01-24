    using System;
    using System.Runtime.InteropServices;
    namespace CoreApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string test  = "ABCDEF"; // Strings are immutable, right?
                char[]       chars = new StringToChar { str = test }.chr;
                chars[0] = 'X';
                // On an x32 release or debug build or on an x64 debug build, 
                // the following prints "XBCDEF".
                // On an x64 release build, it prints "ABXDEF".
                // In both cases, we have changed the contents of 'test' without using
                // any 'unsafe' code...
                Console.WriteLine(test);
                // The following line is even more disturbing, since the constant
                // string "ABCDEF" has been mutated too (because the interned 'constant' string was mutated).
                Console.WriteLine("ABCDEF");
            }
        }
        [StructLayout(LayoutKind.Explicit)]
        public struct StringToChar
        {
            [FieldOffset(0)] public string str;
            [FieldOffset(0)] public char[] chr;
        }
    }
