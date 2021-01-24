    // same for this class.
	public class MyOtherUserInterface : IUserInterface
	{
		public void PrintMenu()
		{
			Console.WriteLine("1) Submenu 1");
			Console.WriteLine("2) Submenu 2");
			Console.WriteLine("3) Submenu 3");
		}
        public bool SendMenuCommand(int command)
        {
            // do something.
            return true;
        }
	}
