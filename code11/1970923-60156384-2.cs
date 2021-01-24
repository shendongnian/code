    public class Robot
	{
		private static List<string> names;
		private static Random rnd = new Random();
		public string Name { get; private set; }
		
		static Robot()
		{
			Console.WriteLine("Initializing");
			// Generate possible candidates
			names = Enumerable.Range(0, 675999).Select(i => 
			{
				var sb = new StringBuilder(5);
				sb.Append((char)('A' + i % 26));
				i /= 26;
				sb.Append((char)('A' + i % 26));
				i /= 26;
				sb.Append(i % 10);
				i /= 10;
				sb.Append(i % 10);
				i /= 10;
				sb.Append(i % 10);
				return sb.ToString();
			}).ToList();
		}
		
		public Robot()
		{
			// Note: if this needs to be multithreaded, then you'd need to do some work here
            // to avoid two threads trying to take a name at the same time
            // Also note: you should probably check that names.Count > 0 
            // and throw an error if not
			var i = rnd.Next(0, names.Count - 1);
			Name = names[i];
			names.RemoveAt(i);
		}
	}
