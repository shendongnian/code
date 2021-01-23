    int[] integers = new int[] {0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1};
    List<int> results = new List<int>();
    for (int pos = 0; pos < integers.Length; pos++)
    {
        if (pos > 2)
        {
            if (integers[pos - 1] == integers[pos - 2] && integers[pos - 2] == integers[pos - 3])
            {
                results.Add(integers[pos]);
            }
        }
    }
