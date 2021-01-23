    var fruitsJson = "{ \"boxes\": 2, \"box\": [ { \"apples\": \"6\", \"bananas\": \"3\", \"oranges\": \"4\", \"lemons\": \"2\" }, { \"peaches\": \"4\", \"limes\": \"5\", \"melons\": \"5\", \"apples\": \"2\" } ] }";
    
    public class Fruits
    {
    	public int boxes { get; set; }
    	public List<Dictionary<string,string>> box { get; set; }
    }
    
    var fruits = fruitsJson.FromJson<Fruits>();
