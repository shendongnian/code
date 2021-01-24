    public static class Program
    {
    	static void Main(string[] args)
    	{
    		string str = @"{
    			'name': 'Child1',
    			'Children': {
    			   'item': {
    				   'id': 'car',
    				   'type': 'car'
    			   }
    		   }
    		}";
    
    		Parent parent = JsonConvert.DeserializeObject<Parent>(str);
    	}
    }
    
    public class Parent
    {
    	[JsonProperty("name")]
    	public string Name { get; set; }
    
    	[JsonProperty("Children")]
    	public Children Children { get; set; }
    }
    
    public class Children
    {
    	[JsonProperty("item")]
    	public Item Item { get; set; }
    }
    
    public class Item
    {
    	[JsonProperty("id")]
    	public string Id { get; set; }
    
    	[JsonProperty("type")]
    	public string Type { get; set; }
    }
