    int[] array = new[] { 0, 2, 2, 8, 4, 6, 1, 0, 4 };
    List<int> result = new List<int>();
    foreach (int element in array)
    {
        if (!result.Contains(element))
            result.Add(element);
    }
    int[] resultArray = result.ToArray();
