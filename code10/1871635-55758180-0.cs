    string json = "{\"action\":\"recognition\",\"command\":\"event\",\"eventid\":[\"1108\"],\"from_ip\":\"192.168.0.49\",\"user\":\"safetymaster\"}\n"; json = json.Replace("\n", "");
    
    Dictionary<string, object> jsonDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
    
    var jsonDic2 = jsonDic.ToDictionary(
    	x => x.Key, 
    	x => x.Value.ToString()
    );
