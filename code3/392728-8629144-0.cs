    // Using long just to avoid having to change if we want a higher limit :)
    public static IEnumerable<long> Fibonacci()
    {
        long current = 0;
        long next = 1;
        while (true)
        {
            yield return current;
            long temp = next;
            next = current + next;
            current = temp;
        }
    }
    ...
    long evenSum = Fibonacci().TakeWhile(x => x < 4000000L)
                              .Where(x => x % 2L == 0L)
                              .Sum();
