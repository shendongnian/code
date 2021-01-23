    public static IEnumerable<TResult> SelectParse<TResult>(
                                           this IEnumerable<string> source)
    {
        foreach(string a in source)
        {
            try
            {
                var parsed = TResult.Parse(a);
                yield return parsed;
            }
            catch {}
        }
    }
