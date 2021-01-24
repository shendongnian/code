    public class ItemProps
    {
    	public int pageid { get; set; }
    	public string name { get; set; }
    }
    
    public class Item
    {
    	public Dictionary<string, ItemProps> items { get; set; }
    }
    
    public class Root
    {
    	public string key1 { get; set; }
    	public Item key2 { get; set; }
    }
