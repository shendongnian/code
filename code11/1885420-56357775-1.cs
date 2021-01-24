    var json = "{ \"spec\": { \"SOMETHING WITH SPACES\" : \"10\" } }";
    var someObj = JsonConvert.DeserializeObject<SomeObject>(json);
    public class SomeObject
    {
    	public Dictionary<string, object> spec{ get; set; }
    }
