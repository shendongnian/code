    	public static void WritePaths(string fileName, string directory)
		{
			try
			{
				using(StreamWriter sw = new StreamWriter(fileName))
				{
					foreach (string f in Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories))
					{
						sw.WriteLine(f);
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine("Exception: " + ex.Message);
			}			
		}
