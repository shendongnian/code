    public static string FullName(this Dictionary<Id, Category> map, Id id)
    {
        return string.Join(@"/", map.CategoryAndParents(id)
                                    .Select(cat=>cat.Name)
                                    .Reverse());
    }
