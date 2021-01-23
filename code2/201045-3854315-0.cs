    List<string> names = new List<string> { "Tom", "Jerry", "Tom" };
    List<string> distinctNames = new List<string>();
    foreach (var name in names)
    {
        if (!distinctNames.Contains(name))
        {
            distinctNames.Add(name);
        }
    }
