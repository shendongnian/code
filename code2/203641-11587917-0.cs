    public static Dictionary<string, string> ToDictionary(
        Regex regex, GroupCollection groups)
    {
        var groupDict = new Dictionary<string, string>();
        foreach (string name in regex.GetGroupNames()){ //the only way to get the names
            Group namedGroup = groups[name]; //test for existence
            if (namedGroup.Success)
                groupDict.Add(name, namedGroup.Value);
        }
        return groupDict;
    }
