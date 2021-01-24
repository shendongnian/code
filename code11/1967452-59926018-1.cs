    public static List<int> EvenlyDistribute(List<int> list)
    {
        List<int> original = list;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        list.ForEach(x => dict[x] = dict.Keys.Contains(x) ? dict[x] + 1 : 1);
            
        list = list.Where(x => dict[x] == 1).ToList();
        foreach (int key in dict.Where(x => x.Value > 1).Select(x => x.Key))
        {
            int iterations = original.Where(x => x == key).Count();
            for (int i = 0; i < iterations; i++)
                list.Insert((int)Math.Ceiling((decimal)((list.Count + iterations) / iterations)) * i, key);
        }
            
        return list;
    }
**Usage in main:**
    List<int> test = new List<int>() {11,11,11,13,14,15,16,17,18,19,19,19,19};
    List<int> newList = EvenlyDistribute(test);
**Output**
19,11,13,19,14,11,19,15,16,19,11,17,18
