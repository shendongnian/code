    public static void PushNamesToList(List<string> names, List<RootObject> rootObject)
    {
        foreach (var row in rootObject)
        {
            names.Add(row.name);
            if (row.children.Count > 0) PushNamesToList(names, row.children);
        }
    }
