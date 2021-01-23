    class MainClass
	{
		public static void Main (string[] args)
		{
			WritePaths("files.txt", "/", true);
		}
		
		public static void WritePaths(string fileName, string directory, bool recursive)
		{
			try
			{
				string[] files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
				using(StreamWriter sw = new StreamWriter(fileName))
				{
					foreach(string file in files)
					{
						sw.WriteLine(file);	
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine("Exception: " + ex.Message);
			}			
		}
	}
