    class Program
	{
		static void Main(string[] args)
		{
			FileInfo fileInfo = new FileInfo("C:\\foo.txt");
			Console.WriteLine(fileInfo.LastWriteTimeUtc);
		}
	}
