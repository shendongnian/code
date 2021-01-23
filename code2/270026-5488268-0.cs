    class Program
    {
        [Flags]
        enum Bits
        {
            _1 = 1,
            _2 = 2,
            _4 = 4,
            _8 = 8,
            _16 = 16,
            _32 = 32,
            _64 = 64,
            _128 = 128
        }
        static void Main(string[] args)
        {
            var b = (Bits)87;
            Console.WriteLine(b);
            Console.ReadKey();
        }
    }
