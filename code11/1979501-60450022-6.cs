    public static void getNames(List<string> names, List<RootObject> rootObject)
    {
        foreach (var row in rootObject)
        {
            names.Add(row.name);
            if (row.children.Count > 0) getNames(names, row.children);
        }
    }
