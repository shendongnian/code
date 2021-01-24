    public class UserService : IPersistentEntityService<User, int>
    {
        public User Get<U>(U id)
        {
            Console.WriteLine(typeof(U));
    		return null;
        }
    }
	
	public interface IPersistentEntityService<TPersistentEntity, T>
	    where TPersistentEntity : IPersistentEntity<T>
	{
	    TPersistentEntity Get<U>(U id);
	}
	
	void Main()
	{
		UserService service = new UserService();
		service.Get<int>(23);
	}
