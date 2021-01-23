    void Main()
    {
    	var a = new List<string>() { "a","b","c" };
    	var b = new List<string>() { "d" };
    	var c = a.MoveItemsTo(i=>i=="b",b);
    	c.Dump(); // { "d", "b" }
    }
    
    public static class Extensions
    {
    	public static IEnumerable<T> MoveItemsTo<T>(this IEnumerable<T> source, Func<T,bool> Predicate,IEnumerable<T> DestSource)
    	{
    		var newList = new List<T>(DestSource);
    		newList.AddRange(source.Where(Predicate).ToList());
    		return newList;
    	}
    }
