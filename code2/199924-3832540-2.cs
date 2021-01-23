    class Program
    {
        static void Main(string[] args)
        {
    
            List<char> s = "ABCDEFGHIJ".ToList();
    
            for (int x = 0; x < 10; x++)
            {
                s.rotate(x+ 1).ForEach(Console.Write);
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int x = 0; x < 10; x++)
            {
                s.rotate2(x + 1).ForEach(Console.Write);
                Console.WriteLine();
            }
    
            Console.ReadLine();
        }
    }
    
    static class so
    {
        public static List<char> rotate(this List<char> currentList, int periodes)
        {
            while (periodes != 1)
            {
                int x = currentList.Count() - 1;
                return rotate(currentList.Skip(x).
                        Concat(currentList.Take(x)).ToList<char>(), periodes - 1);
            }
            return currentList;
        }
            
        public static List<char> rotate2(this List<char> currentList, int periodes)
        {
            int start = (currentList.Count - periodes) + 1;
            return currentList.Skip(start).Concat(currentList.Take(start)).ToList();
        }
    }
