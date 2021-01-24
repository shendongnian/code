    public interface IHasItemProperty {
    	Item GetItem();
    }
    public class Item: IHasItemProperty {
	    public Item GetItem() {
		   return this;
	    }
	
	    public int UserId {get; set;}
    }
    
    public class Record: IHasItemProperty {
    	public Item item{get;set;}
    	
    	public Item GetItem() {
    		return this.item;
    	}
    }
    public class Repo
    {
    	protected Expression<Func<T, bool>> ItemIsOnAccount<T>() where T: IHasItemProperty
    	{
    		return entity => entity.GetItem().UserId == 5;
    	}
    		
    }
    
