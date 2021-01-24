    public class CalledExe
    {
        public static int ADD(int a, int b) { return a + b; }
		public static void Main(string[] args)
		{
			int a, b;
			if (args == null && !args.Any())
				return;
			if (args.Count() != 2)
				return;
			if (args.Count() == 2)
				if (int.TryParse(args[0], out a) && int.TryParse(args[1], out b))
					ADD(a, b);
		}//end void function Main
	}//end CalledExe class
