	abstract class AuthenticationToken
	{
	}
	
	interface IAthentication<T> where T : AuthenticationToken
	{
		bool Authenticate(string name, T token);
	}
	
	class DoorKey : AuthenticationToken
	{
	}
	
	interface IDoorAthentication : IAthentication<DoorKey>
	{
	}
	
	class DoorUnlocker : IDoorAthentication
	{
		public bool Authenticate(string name, DoorKey token)
		{
		}
	}
