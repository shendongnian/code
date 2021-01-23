	class Program
	{
		static void Main(string[] args)
		{
			string[] paths = Directory.GetFiles(@"C:\temp", "*.jpg");
			DirectoryInfo di = new DirectoryInfo(@"C:\temp");
			Stopwatch sw = new Stopwatch();
			sw.Start();
			foreach (FileInfo fi in di.GetFiles("*.jpg"))
			{
				Compress(fi);
			}
			sw.Stop();
			Console.WriteLine("Sequential: " + sw.ElapsedMilliseconds);
			Console.WriteLine("Delete the results files and then rerun...");
			Console.ReadKey();
			sw.Reset();
			sw.Start();
			Parallel.ForEach(di.GetFiles("*.jpg"), (fi) => { Compress(fi); });
			sw.Stop();
			Console.WriteLine("Parallel: " + sw.ElapsedMilliseconds);
			Console.ReadKey();
		}
		public static void Compress(FileInfo fi)
		{
			using (FileStream inFile = fi.OpenRead())
			{
				if ((File.GetAttributes(fi.FullName)
					& FileAttributes.Hidden)
					!= FileAttributes.Hidden & fi.Extension != ".gz")
				{
					using (FileStream outFile =
								File.Create(fi.FullName + ".gz"))
					{
						using (GZipStream Compress =
							new GZipStream(outFile,
							CompressionMode.Compress))
						{
							inFile.CopyTo(Compress);
						}
					}
				}
			}
		}
	}
