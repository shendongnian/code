    public static class DataSetEx
    {
    	private static Dictionary<Type, System.Delegate> __maps
    		= new Dictionary<Type, System.Delegate>();
    	
    	public static void RegisterMap<T>(this Func<DataRow, T> map)
    	{
    		__maps.Add(typeof(T), map);
    	}
    
    	public static IEnumerable<T> GetList<T>(this DataSet dataSet)
    	{
    		var map = (Func<DataRow, T>)(__maps[typeof(T)]);
    		return dataSet.Tables[0].AsEnumerable().Select(map);
    	}
    }
