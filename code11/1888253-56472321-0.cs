    public class Data
    {
    	public int itemId { get; set; }
    	public int minAmount { get; set; }
    	public int maxAmount { get; set; }
    	public int rate { get; set; }
    	public int rarity { get; set; }
    	public int announce { get; set; }
    }
    
    ...
    
    var result = JsonConvert.DeserializeObject<Dictionary<string, Data[]>>("your json here");
