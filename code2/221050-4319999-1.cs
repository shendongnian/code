    using System;
    using System.Runtime.InteropServices;
    
    unsafe class Program {
        static void Main(string[] args) {
            int variable = 42;
            int* p = &variable;
            Console.WriteLine(*p);
            IntPtr raw = (IntPtr)p;
            Marshal.WriteInt32(raw, 666);
            p = (int*)raw;
            Console.WriteLine(*p);
            Console.ReadLine();
        }
    }
