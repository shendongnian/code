        static List<List<int>> GetCombinations(List<int> list)
        {
            var allCombinations = new List<List<int>>();
            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
                int total = 0;
                var combination = new List<int>();
                for (int j = 0; j < list.Count; j++)
                {
                    if (str[j] == '1')
                    {
                        if (total + list[j] <= 10)
                        {
                            total += list[j];
                            combination.Add(list[j]);
                        }
                    }
                }
                if (combination.Count > 1)
                {
                    if (!allCombinations.Any(c => c.SequenceEqual(combination)))
                    {
                        allCombinations.Add(combination);
                    }
                }
            }
            return allCombinations;
        }
