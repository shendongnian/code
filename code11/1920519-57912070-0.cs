        public object Get()
    {
        string allText = System.IO.File.ReadAllText(@"c:\data.json");
    
        object jsonObject = JsonConvert.DeserializeObject(allText);
        return jsonObject;
    }
