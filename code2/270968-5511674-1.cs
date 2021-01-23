    public static IEnumerable<TResult> SelectParse<TResult>(
                                           this IEnumerable<string> source)
    {
        foreach(string a in source)
        {
            TResult parsed;
            try
            {
                parsed = TResult.Parse(a);
            }
            catch
            {
                continue;
            }
            yield return parsed;
        }
    }
