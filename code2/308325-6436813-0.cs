    Dictionary<DateTime, string> sortableKeys = new Dictionary<DateTime, string>();
    foreach (string key in responses.Keys)
    {
       string[] keySplit = key.Split(" - ");
       sortableKeys.Add(DateTime.Parse(keySplit[0], key));            
    }
