    public IDictionary<string, string> GetInfo(string info)
    {
        var infoDic = new Dictionary<string, string>();
        var str = info.Split('&').ToList();
        for (int x = 0; x < str.Count; x++)
        {
            var pair = str[x].Split('=');
            infoDic.Add(pair[0], pair[1]);
        }
        return infoDic;
    }
