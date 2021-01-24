	public interface IUserServiceFactory
	{
		IUserService GetUserService(string key, string val);
	}
	public class UserServiceFactory : IUserServiceFactory
	{
		public IUserService GetUserService(string key, string val)
		{
			return new UserService(key, val);
		}
	}
