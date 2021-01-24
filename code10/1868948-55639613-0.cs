    public static void Main()
	{
		var obj = new SomeOwnedObject();
            if(obj is IOwnedObject<IBaseUser> o)
                Console.WriteLine("Success"); // This never executes
	}
	
	public interface IOwnedObject<out TUser> where TUser : IBaseUser
	{
		string UserId { get; set; }
		IBaseUser User { get; set; }
	}
	public interface IBaseUser
	{
		string Id { get; set; }
	}
	public class User : IBaseUser
	{
		public string Id { get; set; }
	}
	public class SomeOwnedObject : IOwnedObject<User>
	{
		public string UserId { get; set; }
		public IBaseUser User { get; set; }
	}
