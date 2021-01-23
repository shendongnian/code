    class Program
    {
        static void Main(string[] args)
        {
            foreach (IEnumerable<int> grp in nums.GroupsOfN(5))
                Console.WriteLine(String.Join(", ", grp));
    
            Console.ReadKey();
        }
    
        static List<int> nums = new List<int>()
        {
            3,
            27,
            53,
            79,
            113,
            129,
            134,
            140,
            141,
            142,
            145,
            174,
            191,
            214,
            284,
            284
        };
    
        
    }
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<int>> GroupsOfN(this IEnumerable<int> source, int n)
        {
            var sortedNums = source.OrderBy(s => s).ToList();
    
            List<int> items = new List<int>();
            for (int i = 0; i < sortedNums.Count; i++)
            {
                int thisNumber = sortedNums[i];
    
                if (i + 1 == sortedNums.Count)
                {
                    yield return items;
                }
                else
                {
                    int nextNumber = sortedNums[i + 1];
                    items.Add(thisNumber);
    
                    if (nextNumber - thisNumber > n)
                    {
                        yield return items.ToList();
                        items.Clear();
                    }
                }
            }
        }
    }
