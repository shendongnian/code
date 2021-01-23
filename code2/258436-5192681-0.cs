    using System;
    
    class Program
    {
        static void Main()
        {
            // Demonstrate XOR for two integers.
            int a = 5550 ^ 800;
            Console.WriteLine(GetIntBinaryString(5550));
            Console.WriteLine(GetIntBinaryString(800));
            Console.WriteLine(GetIntBinaryString(a));
            Console.WriteLine();
    
            // Repeat.
            int b = 100 ^ 33;
            Console.WriteLine(GetIntBinaryString(100));
            Console.WriteLine(GetIntBinaryString(33));
            Console.WriteLine(GetIntBinaryString(b));
        }
    
        /// <summary>
        /// Returns binary representation string.
        /// </summary>
        static string GetIntBinaryString(int n)
        {
            char[] b = new char[32];
            int pos = 31;
            int i = 0;
    
            while (i < 32)
            {
                if ((n & (1 << i)) != 0)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                i++;
            }
            return new string(b);
        }
    }
    
    ^^^ Output of the program ^^^
    
    00000000000000000001010110101110
    00000000000000000000001100100000
    00000000000000000001011010001110
    
    00000000000000000000000001100100
    00000000000000000000000000100001
    00000000000000000000000001000101
