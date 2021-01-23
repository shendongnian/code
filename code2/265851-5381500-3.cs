    static IEnumerable<string> Search<T>(string searchValue) where T : class, ISearch
    {
        var current = Assembly.GetExecutingAssembly();
        var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                        where !t.IsInterface
                        where typeof(T).IsAssignableFrom(t)
                        select (dynamic)Activator.CreateInstance(t);
        foreach (var item in instances)
        {
            foreach (var occurrence in item.Search(searchValue))
            {
                yield return occurrence;
            }
        }
    }
