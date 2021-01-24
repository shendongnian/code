    using System;
    namespace CoreApp1
    {
        class Program
        {
            const string constFoo = "FOO";
            static unsafe void Main(string[] args)
            {
                fixed (char* p = constFoo)
                {
                    for (int i = 0; i < constFoo.Length; i++)
                        p[i] = 'M';
                }
                // Madness ensues: The next line prints "MMM":
                Console.WriteLine("FOO"); // Prints the interned value of "FOO" which is now "MMM"
            }
        }
    }
