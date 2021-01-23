    public static List<List<int>> GetCombination(List<int> lst, int index, int count)
    {
        List<List<int>> combinations = new List<List<int>>();
        List<int> comb;
        if (count == 0 || index == lst.Count)
        {
            return null;
        }
        for (int i = index; i < lst.Count; i++)
        {
            comb = new List<int>();
            comb.Add(lst.ElementAt(i));
            combinations.Add(comb);
            var rest = GetCombination(lst,i + 1, count - 1);
            if (rest != null)
            {
                foreach (var item in rest)
                {
                    combinations.Add(comb.Union(item).ToList());
                }
            }
        }
        return combinations;
    }
