    // The class implements that interface, which it MUST implements the methods.
    // defined in the interface.  (except abstract classes)
	public class MyUserInterface : IUserInterface
	{
		public void PrintMenu()
		{
			Console.WriteLine("1 - Option one");
			Console.WriteLine("2 - Option two");
			Console.WriteLine("3 - Option three");
		}
        public bool SendMenuCommand(int command)
        {
            // do something.
            return false;
        }
	}
