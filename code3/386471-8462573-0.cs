    public static List<TResult> LoadFromFile<TResult>(string location,
                                                      Func<string, TResult> selector)
    {
        return File.ReadLines(location).Select(selector).ToList();
    }
