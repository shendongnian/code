    public bool isValidJSON(string json)
    {
        try
        {
            JToken token = JObject.Parse(json);
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
    }
