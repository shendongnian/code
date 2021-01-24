        var s = "{  \"DateTimeZulu\": \"2019-06-12T08:50:20.626Z\",  \"DateTimeUtc\": \"2019-06-12T08:50:20.626+00:00\" }";
        var jsonEntity = (JObject.Parse(s));
        foreach (KeyValuePair<string, JToken> current in jsonEntity)
        {  
            Console.WriteLine(current.Key + " - " + ((DateTime)current.Value).ToLocalTime().ToString());
            Console.WriteLine(current.Key + " - " + ((DateTime)current.Value).ToUniversalTime().ToString());
        }
