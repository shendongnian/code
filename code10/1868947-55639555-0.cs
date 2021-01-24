    public interface IOwnedObject<out TUser> where TUser : IBaseUser
    {
    	string UserId { get; set; }
    	TUser User { get; }
    }
