    public class DataRecordComparer : IEqualityComparer<IDataRecord>
    {
    	public bool Equals(IDataRecord x, IDataRecord y)
    	{
    		var a = new object[x.FieldCount];
    		var b = new object[y.FieldCount];
    		
    		x.GetValues(a);
    		y.GetValues(b);
    		
    		return a.SequenceEqual(b);
    	}
    
    	public int GetHashCode(IDataRecord obj)
    	{
    		var values = new object[obj.FieldCount];
            obj.GetValues(values);
    		unchecked
    		{
    			int hash = 17;
    			foreach (var item in values)
    				hash = hash * 23 + ((item != null) ? item.GetHashCode() : 0);
    
    			return hash;
    		}
    	}
    }
