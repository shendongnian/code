    public static IEnumerable<Task<TResult>> EmitOverTime<TResult>(
        this IEnumerable<Task<TResult>> tasks, int delay)
    {
        foreach (var item in tasks)
        {
            Thread.Sleep(delay); // Delay by blocking
            yield return item;
        }
    }
