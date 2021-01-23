    static readonly Dictionary<Type, object> defaultMap = new Dictionary<Type, object>()
    		{
    			{ typeof(DateTime), DateTime.MinValue },
    			{ typeof(Int32), 0},
    			{ typeof(String), ""}
    			/* etc etc etc*/
    		};
    
    private static void SetDefault(Type type, ref object value)
    {
    	if(value == DBNull.Value || value == null)
    		value = defaultMap[type];
    }
