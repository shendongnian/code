    class Program
    {
        static void Main(string[] args)
        {
            int[] luvut = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(Kuuluuko(luvut));
            Console.ReadKey();
        }
        private static int Kuuluuko(int[] luvut)
        {
            var random = new Random();
            return luvut[random.Next(0, luvut.Length)];
        }
    }
