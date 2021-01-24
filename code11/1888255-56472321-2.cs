    public class Data
    {
    	public int itemId { get; set; }
    	public int minAmount { get; set; }
    	public int maxAmount { get; set; }
    	public decimal rate { get; set; }
    	public string rarity { get; set; }
    	public bool announce { get; set; }
    }
    
    ...
    
    var result = JsonConvert.DeserializeObject<Dictionary<string, Data[]>>("your json here");
