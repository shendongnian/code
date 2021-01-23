    public class MyMembershipService : IMembershipService
    {
    	private readonly IUserRepository userRepository;
    
    	public MyMembershipService(IUserRepository userRepository)
    	{
    		this.userRepository = userRepository;
    	}
    
    	public virtual bool IsValid(string username, string password)
    	{
    		var user = userRepository.FindByUsername(username);
    
    		return user != null && user.PasswordMatches(password);
    	}
    
    	public virtual bool AllowedToLogIn(string username)
    	{
    		var user = userRepository.FindByUsername(username) ?? new User();
    
    		return user.AllowedToLogIn();
    	}
    }
