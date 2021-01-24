    public class RootClass
    {
    	public IdsModel IdsModel { get; set; }
    }
    
    public class IdsModel
    {
    	public List<long> IdsToDraft { get; set; }
    }
    
    // ...
    
    var idsModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RootClass>(body);
