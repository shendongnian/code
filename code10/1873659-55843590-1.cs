    public class JsonHolder
    {
    public string Id {get;set;}
    public string Name {get;set;}
    public string Gender {get;set;}
    }
    
    List<JsonHolder> objJsonHolder = new JsonConvert.DeserializeObject<List<JsonHolder>>(JsonString);
