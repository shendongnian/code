    public interface IItem
    {
    }
    public abstract class Item<T> where T : IItem
    {
    	public virtual void OnItemEquipped(T item)
    	{
    	}
    }
    
    public class Item_Armour :Item<Item_Armour>,IItem
    {
    	public string UniqueFloat{get;set;}
    	public override void OnItemEquipped(Item_Armour item)
    	{
    		UseUniqueFloat(item.UniqueFloat);
    	}
    	
    	public void UseUniqueFloat(string uniqueFloat)
    	{
    	}
    }
