    sealed public class FriendManager
    {
    	private UsersDataContext dbContext = new UsersDataContext();
    
    	public IQueryable<User> GetFriendsByDisplayName(string namePart)
    	{
    		// assumes the existence of the class UsersDataContext (dbml file)
    		IQueryable<User> result =
    			this.dbContext.Users.Where(u => u.DisplayName.ToLower().Contains(namePart.ToLower()));
    
    		return result;
    	}
    }
