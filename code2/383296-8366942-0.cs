    public class GroupItem<T>
    {
    	// ... Code for GroupItem<T>
    }
    
    public class GroupItems<T>
    {
    	private List<GroupItem<T>> mItems = new List<GroupItem<T>>();
    	
    	public void Add(T item)
    	{
    		mItems.Add(item);
    	}
    	
    	public T GetItem(int index)
    	{
    		return mItems[index];
    	}
    }
