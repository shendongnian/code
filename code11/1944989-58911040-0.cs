    List<int> output = new List<int>();
    List<int> input = new List<int>(arr);
    while (input.Count > 0)
    {
        output.Add(input.Count);
        int min = input.Min();
        input.RemoveAll(x => x == min);
        input.ForEach(x => x -= min);
    }
    return output.ToArray();
