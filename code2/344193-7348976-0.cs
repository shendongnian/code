    List<string> months = new List<string>();
    foreach (Dictionary<string, string> aDict in data)
    {
        string aMonth;
        if (aDict.TryGetValue("Month", out aMonth))
            months.Add(aMonth);
    }
