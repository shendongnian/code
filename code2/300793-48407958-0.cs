    public class MyOwnDictionary<TKey, TValue>: Dictionary<TKey, TValue>
    {
    	public void AddPlus(TKey key, TValue value)
    	{
    		//some custom logic here
    		
    		base.Add(key,value);
    	}
    }
