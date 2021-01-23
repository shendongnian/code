	public static class FileUtilities
	{
		public static IEnumerable<string> Lines(string filename)
		{
			if (filename == null)
				throw new ArgumentNullException("filename");
			return LinesCore(filename);
		}
		private static IEnumerable<string> LinesCore(string filename)
		{
			Debug.Assert(filename != null);
			using(var reader = new StreamReader(filename))
			{
				while (true)
				{ 
					string line = reader.ReadLine();
					if (line == null) 
					   yield break;
					yield return line;
				}
			}
		}
	}
