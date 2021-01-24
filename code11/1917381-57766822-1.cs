    public bool PostString(string json)
    {
        Model model = JsonConvert.DeserializeObject<Model>(json);
        return true;
    }
    public bool PostStream(Stream value)
    {
        // Read the stream into a string
        string json;
        using(var streamReader = new StreamReader(stream))
        {
            json = streamReader.ReadToEnd();
        }     
        // Deserialise string to object       
        Model model = JsonConvert.DeserializeObject<Model>(json);
        return true;
    }
