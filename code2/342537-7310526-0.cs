    private IEnumerable<string> DoWork(IEnumerable<string> data)
    {
        List<string> newData = new List<string>();
        foreach(string item in data)
        {
            newData.Add(item + "roxxors");
        }
        return newData;
    }
