    public static int[][] RemoveDuplicates(this int[][] data)
    {
        var result = new int[data.Length][];
        var used = new List<int>();
        for (int i = 0; i < data.Length; i++)
        {
            var hashSet = new HashSet<int>(data[i].Except(used));
            result[i] = hashSet.ToArray();
            used.AddRange(hashSet);
        }
        return result;
    }
