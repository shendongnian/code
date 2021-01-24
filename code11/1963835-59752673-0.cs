    Dictionary<string, List<string>> Directory = new Dictionary<string, List<string>>();
    Directory.Add("1", new List<string>() { "alpha", "bravo", "charlie" });
    Directory.Add("2", new List<string>() { "delta", "echo", "foxtrot" });
    Directory.Add("3", new List<string>() { "golf", "charlie", "India" });
    string stringToRemove = "charlie";
    Directory.Where(x => x.Value.Contains(stringToRemove))
                .ToList()
                .ForEach(x => x.Value.Remove(stringToRemove));
After the execution, "charlie" is gone from all dictionary's pairs.
