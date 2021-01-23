    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0x2500; i <= 0x2570; i += 0x10)
            {
                for(int c = 0; c < 0xF; ++c)
                {
                    Console.Write((char) (i + c));
                }
    
                Console.WriteLine();
            }
        }
    }
