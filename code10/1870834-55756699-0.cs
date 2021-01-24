    public partial class TopNode
    {
    	public T GetItem<T>()
    	{
    		var result = Items.FirstOrDefault(r => r.GetType() == typeof(T));
    		return (T)result;
    	}
    
    	public List<T> GetItems<T>()
    	{
    		var results = Items.Where(r => r.GetType() == typeof(T)).Select(r => (T)r).ToList();
    		return (List<T>)results;
    	}
    }
