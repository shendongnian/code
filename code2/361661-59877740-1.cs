        static void Main(string[] args)
        {
            GetCombination(new List<int> { 1, 2, 3 });
        }
        private static void GetCombination(List<int> list)
        {
            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    int b = i & (1 << j);
                    if (b > 0)
                    {
                        Console.Write(list[j]);
                    }
                }
                Console.WriteLine();
            }
        }
