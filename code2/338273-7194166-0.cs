    static string MyParserJson(string sjson, string key)
    {
        try
        {
            if (!(sjson.Contains("{") && sjson.Contains("}")))
                throw new ApplicationException("don't exist { or }");
    
            int inipos = sjson.IndexOf("{");
            int endpos = sjson.IndexOf("}");
    
            var myjson = sjson.Substring(inipos + "{".Length, endpos - (inipos + "{".Length));
            string[] ajson = myjson.Split('&');
    
            foreach (var keyval in ajson)
            {
                if (!keyval.Contains(":"))
                    continue;
    
                string[] afind = keyval.Split(':');
    
                if (afind[0].Contains(key))
                {
                    return afind[1].Replace("\"", "").Replace("\\", "").Trim();
                }
            }
    
        }
        catch
        {
              //test
        }
    
        return string.Empty;
    }
    
    
    var uri = "?{\"token\":\"I3dt-MIByyWD5-XqF6VT3hQSk8qvy9r6\"}";
    var token = MyParserJson(uri, "token");
