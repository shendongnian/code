    // TODO: Documentation
    public static void ConsumeSequence<T>(this IEnumerable<T> source)
    {
        // TODO: Argument validation
        using (var iterator = source.GetEnumerator())
        {
            while (iterator.MoveNext())
            {
                // Deliberate no-op
            }
        }
    }
