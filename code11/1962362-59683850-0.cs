    public class Rootobject
    {
    	public int Id { get; set; }
    	[JsonConverter(typeof(CustomItemConverter))]
    	public Dictionary<DateTime, Item[]> Los { get; set; }
    }
    
    public class Item
    {
    	[JsonIgnore]
    	public DateTime Date { get; set; }
    	public string Currency { get; set; }
    	public int Guests { get; set; }
    	public int[] Price { get; set; }
    }
