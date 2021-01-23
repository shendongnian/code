    public string[] GetGroupNames(Regex re)
    {
        var groupNames = re.GetGroupNames();
        var groupNumbers = re.GetGroupNumbers();
        Contract.Assert(groupNames.Length == groupNumbers.Length);
        return Enumerable.Range(0, groupNames.Length)
            .Where(i => groupNames[i] != groupNumbers[i].ToString())
            .Select(i => groupNames[i])
            .ToArray();
    }
