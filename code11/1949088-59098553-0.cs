    public List<T> Json2List<T>(string s)
    {
        string json_object = JsonConvert.DeserializeObject<string>(s);
        return JsonConvert.DeserializeObject<List<T>>(json_object);
    }
