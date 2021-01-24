    public static List<int> EvenlyDistribute(List<int> list)
    {
        int totalLength = list.Count;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        list.ForEach(x => dict[x] = dict.Keys.Contains(x) ? dict[x] + 1 : 1);
        List<int> listWithoutDuplicates = list.Where(x => dict[x] == 1).ToList();
        foreach (int key in dict.Keys)
        {
            if (dict[key] > 1)
            {
                int iterations = list.Where(x => x == key).Count();
                int places = (int)Math.Ceiling((decimal)((listWithoutDuplicates.Count + iterations) / iterations));
                for (int i = 0; i < iterations; i++)
                    listWithoutDuplicates.Insert(places * i, key);
            }
        }
        return listWithoutDuplicates;
    }
**Usage in main:**
    List<int> test = new List<int>() {11,11,11,13,14,15,16,17,18,19,19,19,19};
    List<int> newList = EvenlyDistribute(test);
**Output**
19,11,13,19,14,11,19,15,16,19,11,17,18
