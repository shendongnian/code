    public List<string> GetDirectoryList()
    {
    var directoryList = new List<string>();
    var list = Directory.GetDirectories(sourcePath);
    string stringPattern = "(?<!\d)[0-9]{10}(?!\d)";
    foreach (var field in list)
    {
        if (Regex.IsMatch(checkingInfo, stringPattern))
        {
            directoryList.Add(field);
        }
    }
    return directoryList;
    }
