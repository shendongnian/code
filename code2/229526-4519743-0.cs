    class Program
    {
        private static List<int> l = new List<int> { 1, 2, 3, 4, 5 };
    
        static void Main(string[] args)
        {
            Console.WriteLine(GetNum(x => x > 3));
            Console.ReadKey();
        }
    
        private static int GetNum(Func<int, bool> predicate)
        {
            return l.Where(predicate).FirstOrDefault();
        }
    }
