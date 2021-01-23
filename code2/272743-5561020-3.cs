    IEnumerable<T> EnumerateResults<T>(IEnumerable<T> results)
    {
        if (results.IsNull()) yield break;
        foreach (T result in results)
        {
            // ..Common logic lines...
            yield return result;
        }
    }
