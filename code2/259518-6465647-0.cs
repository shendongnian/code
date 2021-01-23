    internal static class TLSAdapter
    {
    	static Dictionary<string, LocalDataStoreSlot> tlsSlots = new Dictionary<string, LocalDataStoreSlot>();
    		
    	public static bool DoesNamedDataSlotsExist(string name)
    	{
    		lock(tlsSlots)
    		{
    			return tlsSlots.ContainsKey(name);
    		}
    		
    	}
    	
    	public static LocalDataStoreSlot AllocateNamedDataSlot (string name)
    	{
    		lock(tlsSlots)
    		{
    			LocalDataStoreSlot slot = null;
    			if ( tlsSlots.TryGetValue(name, out slot) )
    				return slot;
    				
    			slot = Thread.GetNamedDataSlot(name);
    			tlsSlots[name] = slot;
    			return slot;			
    		}		
    	}	
    }
