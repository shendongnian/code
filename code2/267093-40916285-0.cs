    public static class DbExtensions
    {
    	public static T ReadAs<T>(this IDataReader reader, string col)
    	{
    		object val = reader[col];
    		if (val is DBNull)
    		{
    			// Use the default if the column is null
    			return default(T);
    		}
    		return (T)val;
    	}
    }
