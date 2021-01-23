    UpdateNames(itemsDictionary, blueprints);
    UpdateNames(itemsDictionary, blueprints.SelectMany(x => x.Input.Keys));
    ...
    private static void UpdateNames<TSource>(Dictionary<string, string> idMap,
        IEnumerable<TSource> source) where TSource : INameAndId
    {
        foreach (TSource item in source)
        {
            string name;
            if (idMap.TryGetValue(item.Id, out name))
            {
                item.Name = name;
            }
        }
    }
