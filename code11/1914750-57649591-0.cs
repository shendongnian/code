	using System;
	using System.Collections.Generic;
	public class Program
	{
		public delegate object GenericCommand (params object[] parameters);
		public static object Function1 (params object[] parameters) => Function1 ((int)parameters[0], (int)parameters[1]);
		public static int Function1 (int i, int j) => (i + j);
		private static Dictionary<string, GenericCommand> commands;
		public static void Main()
		{
			commands = new Dictionary<string, GenericCommand> ();
			commands.Add ("Function1", Function1);
			int i = (int)commands["Function1"](1, 2);
			Console.WriteLine (i); // 3
		}	
	}
