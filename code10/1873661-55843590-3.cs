    public class JsonHolder
    {
        public string Id {get;set;}
        public string Name {get;set;}
        public string Gender {get;set;}
    }
    
    var jsonHolderList = new JsonConvert.DeserializeObject<List<JsonHolder>>(jsonString);
    var jsonHolder = jsonHolderList.Single()
