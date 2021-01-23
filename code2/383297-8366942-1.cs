    public interface IGroupItem
    {
    	// ... Common GroupItem properties and methods
    }
    
    public class GroupItem<T>
    {
    	// ... Code for GroupItem<T>
    }
    
    public class GroupItems
    {
    	private List<IGroupItem> mItems = new List<IGroupItem>();
    	
    	public void Add(IGroupItem item)
    	{
    		mItems.Add(item);
    	}
    	
    	// This is a generic method to retrieve just any group item.
    	public IGroupItem GetItem(int index)
    	{
    		return mItems[index];
    	}
    	
    	// This is a method that will get a group item at the specified index
    	// and then cast it to the specific group item type container.
    	public GroupItem<T> GetItem<T>(int index)
    	{
    		return (GroupItem<T>)mItems[index];
    	}
    }
