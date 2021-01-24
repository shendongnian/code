    public class MyQueue<T>
    { 
    	private List<(string Key, T Value)> items = new List<(string Key, T Value)>();
    	
    	public void Enqueue(T item, string uniqueID)
    	{
    		var found = items.Select((value, index) => new { value, index}).FirstOrDefault(x => x.value.Key == uniqueID);
    		if(found == null)
    			items.Add((uniqueID, item));
    		else
    			items[found.index] = (uniqueID, item);
    	}
    	
    	public T Dequeue()
    	{
    		var item = items[0];
    		items.RemoveAt(0);
    		return item.Value;
    	}
    	
    	public T Peek()
    	{
    		return items[0].Value;
    	}
    }
