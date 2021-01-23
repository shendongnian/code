	public interface IMyService
	{
		SomeResponse SomeMethod(object param1, object param2);
	}
	public class MyService : IMyService
	{
		public SomeResponse SomeMethod(object param1, object param2)
		{
			// do stuff
		}
	}
