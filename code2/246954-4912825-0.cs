    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                System.Collections.BitArray bits = new System.Collections.BitArray(900);
                // Setting all bits to 0
                bits.SetAll(false);
                // Here Im setting 21st bit in array
                bits[21] = true;
                // etc...
                int[] nativeBits = new int[29];
                // Packing your bits in int array
                bits.CopyTo(nativeBits, 0);
                // This prints 2097152. this is 2^21
                Console.WriteLine("First element is:"+nativeBits[0].ToString());
            }
        }
    }
