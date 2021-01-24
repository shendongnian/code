	public class MyClass
	{
		public static Action<string> LogMehod;
		
		public void Log(string s)
		{
            // call the static log method if it is assigned.
            if(LogMehod != null)
			    LogMehod(User + ": " + s);
		}
        public string User {get;set;}
	}
	class Program
	{
		static Main()
		{
            // assign an lambda expression, which displays the passed string.
			MyClass.LogMehod = s =>
			{
				Console.WriteLine(s);
			}
			
            // create an instance of MyClass
			var user1 = new MyClass();
            user1.User = "User1";
			user1.Log("bla");
			
			var user2 = new MyClass();
            user2.User = "User2";
			user2.Log("also bla");
			Console.ReadLine();
		}
	}
