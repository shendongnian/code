	public class MyUserInterface : IUserInterface
	{
		public void PrintMenu()
		{
			Console.WriteLine("1 - Option one");
			Console.WriteLine("2 - Option two");
			Console.WriteLine("3 - Option three");
		}
        public void SendMenuCommand(int command)
        {
            // do something.
        }
	}
