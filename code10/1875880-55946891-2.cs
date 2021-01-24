    public class MyQueue<T>
    { 
    	private OrderedDictionary items = new OrderedDictionary();
    	
    	public void Enqueue(T item, string uniqueID)
    	{
    		if(items.Contains(uniqueID))
    			items[uniqueID] = item;
    		else
    			items.Add(uniqueID, item);
    	}
    	
    	public T Dequeue()
    	{
    		var item = items[0];
    		items.RemoveAt(0);
    		return (T)item;
    	}
    	
    	public T Peek()
    	{
    		return (T)items[0];
    	}
    }
