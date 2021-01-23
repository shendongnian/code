	class MapReader
	{
		public string FileName { get; private set; }
		public MapReader(string fName)
		{
			FileName = fName;
		}
		public MapReader() : this(ObtainNameFromConsole())
		{
			
		}
		private static string ObtainNameFromConsole()
		{
			Console.WriteLine("Input valid file name:");
			return Console.ReadLine();
		}
	}
