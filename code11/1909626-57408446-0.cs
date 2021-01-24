    JArray a = JArray.Parse(json);
    var listUser = new List<User>();
    foreach (JObject o in a.Children<JObject>())
    {
        foreach (JProperty p in o.Properties())
        {
            string name = p.Name;
            string value = (string)p.Value;
            var user = new User();
            user.Name = name;
            ...... 
        }
    }
