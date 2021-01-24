    public static partial class UserFilters
    {
    	public static Expression<Func<Item, bool>> OwnsItem(this User user)
    		=> item => item.AccountId == user.AccountId;
    
    	public static Expression<Func<Item, bool>> CanAccessItem(this User user)
    	{
    		if (user.AllowAllItems) return item => true;
    		return item => item.UserItemMappings.Any(d => d.UserId.Value == user.Id) ||
    			item.GroupItemMappings.Any(vm => vm.Group.GroupUserMappings.Any(um => um.UserId == user.Id));
    	}
    }
