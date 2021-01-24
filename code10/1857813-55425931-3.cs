    public static partial class UserFilters
    {
    	public static Expression<Func<T, bool>> Owns<T>(this User user, Expression<Func<T, Item>> item)
    		=> user.OwnsItem().ApplyTo(item);
    
    	public static Expression<Func<T, bool>> CanAccess<T>(this User user, Expression<Func<T, Item>> item)
    		=> user.CanAccessItem().ApplyTo(item);
    }
