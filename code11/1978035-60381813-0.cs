    public static int Sum(this IEnumerable<int> source)
    {
        int sum = 0;
        foreach (int v in source)
        {
            sum += v;
        }
        return sum;
    }
