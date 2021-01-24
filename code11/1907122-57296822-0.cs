    var parsedObject = JObject.Parse(str);
    var popupJson = parsedObject["masterlist"].ToString();
    var popupObj = JsonConvert.DeserializeObject<Dictionary<string, string>>(popupJson);
    var filteredList = popupObj.Where(kvp => kvp.Key.Equal("session") == false).Values;
    List<LegiBill> legiBills = new List<LegiBill>;
    
    foreach(var legiBill in legiBills)
    {
         var obj = JsonConvert.DeserializeObject<LegiBill>(legiBill);
    
         if (obj != null)
         {
             legiBills.add(obj)
         }
    }
    
    return legiBills;
