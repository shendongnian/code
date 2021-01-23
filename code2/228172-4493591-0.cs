    public class SqlQuery
    {
    	private SqlQuery() { }
    
    	private static UInt32 sqlQueriesCount = 0;
    
    	public static UInt32 INBOUND_UPDATE_CALLBACK_NUM = sqlQueriesCount++;
    	public static UInt32 INBOUND_UPDATE_DEST_ADDR_SUBUNIT = sqlQueriesCount++;
    	public static UInt32 INBOUND_UPDATE_DEST_BEARER_TYPE = sqlQueriesCount++;
    	//...etc
    
    	private static readonly Dictionary<UInt32, String> queries = new Dictionary<UInt32, String>
    	{
    	    {SqlQuery.INBOUND_UPDATE_CALLBACK_NUM, "UPDATE inbound SET callbackNum = ? WHERE id = ?"},
    	    {SqlQuery.INBOUND_UPDATE_DEST_ADDR_SUBUNIT, "UPDATE inbound SET destAddrSubunit = ? WHERE id = ?"},
    	    {SqlQuery.INBOUND_UPDATE_DEST_BEARER_TYPE, "UPDATE inbound SET destBearerType = ? WHERE id = ?"},
    	    //...etc
    	};
    
    	public static String GetQueryText(UInt32 queryKey)
    	{
    	    String query = null;
    	    if (SqlQuery.queries.TryGetValue(queryKey, out query) == false)
    	    {
    		throw new ArgumentOutOfRangeException(String.Format("Query must be paramerized query stored within SqlQuery class, provided queryKey: {0}", queryKey));
    	    }
    	    return query;
    	}
    }
