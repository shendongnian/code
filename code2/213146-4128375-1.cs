    public static T GetItemById<T>(int UID) where T:IUniqueIdentity
    {
    	IList<T> mainList = GetAllItems<T>();
    	//assuming there is 1 or 0 occurrences, otherwise FirstOrDefault
    	return mainList.SingleOrDefault(item=>item.UID==UID); 
    
    }
    
    public interface IUniqueIdentity
    {
    	int UID{get;}
    }
