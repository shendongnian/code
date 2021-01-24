    using System;
    using System.Runtime.InteropServices;
    namespace CoreApp1
    {
        class Program
        {
            const string constFoo = "FOO";
            static void Main()
            {
                char[] chars = new StringToChar {str = constFoo }.chr;
                for (int i = 0; i < constFoo.Length; i++)
                {
                    chars[i] = 'M';
                    Console.WriteLine(chars[i]); // Always prints "M".
                }
                Console.WriteLine("FOO"); // x86: Prints "MMM". x64: Prints "FOM".
            }
        }
        [StructLayout(LayoutKind.Explicit)]
        public struct StringToChar
        {
            [FieldOffset(0)] public string str;
            [FieldOffset(0)] public char[] chr;
        }
    }
