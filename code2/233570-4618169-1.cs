    public static IEnumerable<int> GetInfiniteRandomNumbers()
    {
        var rand = new Random();
        while (true)
        {
            yield return rand.Next();
        }
    }
