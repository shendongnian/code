    class Program
    {
        private static int[] table;
        static void Main(string[] args)
        {
            int[] ints = new int[] { 6, 2, 5, 99, 55 };
           table = ints.OrderByDescending(x => x).ToArray();
            foreach (var item in table)
            {
                Console.WriteLine(item);
            }
        }
