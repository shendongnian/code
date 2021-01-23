    int[] input = new int[] { 0, 2, 2, 8, 4, 6, 1, 0, 4 };
    int[] output = DistinctItems(input);  // 0, 2, 8, 4, 6, 1
    // ...
    public static T[] DistinctItems<T>(T[] input)
    {
        Dictionary<T, bool> dict = new Dictionary<T, bool>(input.Length);
        return Array.FindAll(input, delegate(T item)
                                        {
                                            if (dict.ContainsKey(item))
                                                return false;
                                            dict.Add(item, true);
                                            return true;
                                        });
    }
