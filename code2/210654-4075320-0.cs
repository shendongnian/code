        static void Main(string[] args)
        {
            int[] numArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            OddsAndEvens(7, numArray);
            OddsAndEvens(4, numArray);
        }
        public static void OddsAndEvens(int numToPrint, int[] array)
        {
            var a = array.Where(n => n % 2 == 0); // evens
            var b = array.Where(n => !(n % 2 == 0)); // not evens, thus odds
            var ab = a.Take(numToPrint);
            ab = ab.Union(b.Take(numToPrint - ab.Count()));
            foreach (int i in ab)
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("Press any enter to continue...");
            Console.ReadKey();
        }
