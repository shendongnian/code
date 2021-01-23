    public string[] GetGroupNames(Regex re)
    {
        var groupNames = re.GetGroupNames();
        var groupNumbers = re.GetGroupNumbers();
        if (groupNames.Length != groupNumbers.Length) throw new Exception("This shouldn't happen.");
        var realGroupNames = new List<string>();
            
        for (int i = 0; i < groupNames.Length; ++i)
        {
            if (groupNames[i] != groupNumbers[i].ToString())
                realGroupNames.Add(groupNames[i]);
        }
        return realGroupNames.ToArray();
    }
