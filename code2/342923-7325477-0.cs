    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            int[] EmpIds = new int[] { 123, 1234, 1234 };
            int[] PayIds = new int[] { 1, 1, 2 };
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            // populate dictionary
            for (int i = 0; i < EmpIds.Length; i++)
            {
                if (!dict.ContainsKey(EmpIds[i]))
                {
                    List<int> values = new List<int>();
                    dict.Add(EmpIds[i], values);
                }
                dict[EmpIds[i]].Add(PayIds[i]);
            }
            foreach (int k in dict.Keys)
            {
                foreach (int v in dict[k]) Console.WriteLine("{0} -> {1}", k, v);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
    }
