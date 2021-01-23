    public class ItemEvaluator
    {
    	public int Highest { get { return highest; } }
    	public int Lowest { get { return lowest; } }
    	
    	public void Add(Item item)
    	{
    		highest = item.Value > highest ? item.Value : highest;
    		lowest = item.Value < lowest ? item.Value : lowest;
    		items.Add(items);
    	}
    	
    	private List<int> items = new List<int>();
    	private int lowest;
    	private int highest;
    }
    
    public class Item
    {
    	public int Value { get; set; }	
    }
