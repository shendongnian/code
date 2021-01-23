	class Program
	{
		static void Main(string[] args)
		{
			if (2.ContainedIn(1, 2, 3))
			{
				Console.WriteLine("found it!");
			}
		}
	}
	public static class ExtensionMethods
	{
		public static bool ContainedIn(this int val, params int[] vals)
		{
			return vals.Contains(val);
		}
	}
