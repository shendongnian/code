	public interface IMyService
	{
		SomeResponse SomeMethod(object param1, object param2);
	}
	public interface IMyService2
	{
		SomeResponse SomeMethod(object param1, object param2, object param3);
	}
	public class MyService : IMyService, IMyService2
	{
		public SomeResponse SomeMethod(object param1, object param2)
		{
			return SomeMethod(param1, param2, null);
		}
		public SomeResponse SomeMethod(object param1, object param2, object param3)
		{
			// do stuff
		}
	}
