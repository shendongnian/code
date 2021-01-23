        static void Main(string[] args)
        {
            GetCombination(new List<int> { 1, 2, 3 });
        }
        private static void GetCombination(List<int> list)
        {
            var bitwiseList = new List<int>(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                // Builds a list containing [1,2,4,8,16 etc.]
                bitwiseList.Add(1 << i);
            }
            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    int b = i & bitwiseList[j];
                    if (b > 0)
                    {
                        Console.Write(list[j]);
                    }
                }
                Console.WriteLine();
            }
        }
