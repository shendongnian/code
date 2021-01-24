    public static class ExtensionsHelper
    {
    	public static List<TProjection> ProjectAsCollection<TProjection>(this IEnumerable<object> items) where TProjection : class
    	{
    		//var adapter = <Create Type Adapter>
    		return adapter.Adapt<List<TProjection>>(items);
    	}
    }
