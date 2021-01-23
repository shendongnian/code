    public static void HappinessStatus<T>(this IEnumerable<T> items) where T : Human
    {
        foreach (T item in items)
        {
            Console.WriteLine(item.IsHappy.ToString());
        }
    }
