    class Program
    {
        static void Main(string[] args)
        {
            int x = 10; // int -> stack
            int y = x; // assigning the value of num to mun. 
            DisplayMemAddress(ref x);
            DisplayMemAddress(ref y);
            Console.ReadLine();
        }
        static unsafe void DisplayMemAddress(ref int z)
        {
            fixed (int* ptr = &z)
            {
                Console.WriteLine("0x" + new IntPtr(ptr).ToString("x"));
            }
        }
    }
