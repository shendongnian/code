    using System.Collections.Generic;
    using System.Linq;
    
    public static class Extensions
    {
    	public static IEnumerable<(T Previous, T Current, T Next)> Sandwich<T>(this IEnumerable<T> source, T beforeFirst = default, T afterLast = default)
    	{
    		T previous = beforeFirst;
    		T current = source.FirstOrDefault();
    		
    		foreach (var next in source.Skip(1))
    		{
    			yield return (previous, current, next);
    
    			previous = current;
    			current = next;
    		}
    
    		yield return (previous, current, afterLast);
    	}
    }
