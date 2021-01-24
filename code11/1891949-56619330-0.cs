    class Program
    {
        static void Main(string[] args)
        {
            const int Height = 4;
            const int Width = 4;
            for (int y = 0; y < Height; ++y)
            {
                int rowSize = y % 2 > 0 ? Width + 1 : Width;
                for (int x = 0; x < rowSize; ++x)
                {
                    Console.WriteLine($"{x}:{y}");
                }
            }
            Console.ReadLine();
        }
    }
