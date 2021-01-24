    public static partial class UserFilters
    {
    	public static Expression<Func<T, Item>> GetItem<T>() where T : IHasItem
    		=> entity => entity.Item;
    
    	public static Expression<Func<T, bool>> OwnsItem<T>(this User user) where T : IHasItem
    		=> user.Owns(GetItem<T>());
    
    	public static Expression<Func<T, bool>> CanAccessItem<T>(this User user) where T : IHasItem
    		=> user.CanAccess(GetItem<T>());
    }
