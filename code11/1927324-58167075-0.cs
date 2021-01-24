	// Different interfaces
	interface IUserData
	{
		string Email;
		string Password;
	}
	interface IUserNameData
	{
		public abstract string FName;
		public abstract string LName;
	}
	// Abstract class
	abstract class UserProfile : IUserData
	{
		public abstract string Email;
		public abstract string Password;
	}
	// Inherited classs
	class LoginData : UserProfile
	{
		// Implements IUserData
	}
	class UserData : UserProfile, IUserNameData
	{
		// Implements IUserData and IUserNameData
	}
