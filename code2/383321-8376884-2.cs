    public class PhoneDict : Dictionary<string, User>
    {
    	public void Add(User user)
    	{
    		Add(user.PhoneNumber, user);
    	}
    }
