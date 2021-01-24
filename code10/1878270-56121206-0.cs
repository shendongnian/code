    /// <summary>
    /// Get all subsequences of the given sequence.
    /// {1,2,3}=>{{1,2},{1,2,3},{2,3}}
    /// </summary>
    public static T[][] GetAllSubsequences<T>(this IEnumerable<T> collection)
    {
    	var list = (collection as T[]) ?? collection.ToArray();
    	return list.SelectMany((x, i) => list.Skip(i).Select((z, j) =>
    		  {
    			  var arr = new T[j + 1];
    			  Array.Copy(list, i, arr, 0, j + 1);
    			  return arr;
    		  })).ToArray();
    }
