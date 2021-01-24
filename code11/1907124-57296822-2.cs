    public static List<LegiBill> ReadFromJsonStr(string str)
    {
        var parsedObject = JObject.Parse(str);
        var popupJson = parsedObject["masterlist"].ToString();
        var popupObj = JsonConvert.DeserializeObject<Dictionary<string, LegiBill>>(popupJson);
        var filteredList = popupObj.Where(kvp => kvp.Key.Equals("session") == false).Select(x=>x.Value).ToList();
        List<LegiBill> legiBills = new List<LegiBill>(filteredList);
        foreach (var legiBill in filteredList)
        {
            if (legiBill != null)
            {
                legiBills.Add(legiBill);
            }
        }
        return legiBills;
    }
