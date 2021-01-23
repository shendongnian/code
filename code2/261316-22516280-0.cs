	class Program
	{
		static void Main(string[] args)
		{
			const string nobomtxt = "nobom.txt";
			File.Delete(nobomtxt);
			using (Stream stream = File.OpenWrite(nobomtxt))
			using (var writer = new StreamWriter(stream, new UTF8Encoding(false)))
			{
				writer.WriteLine("HelloПривет");
			}
			const string bomtxt = "bom.txt";
			File.Delete(bomtxt);
			using (Stream stream = File.OpenWrite(bomtxt))
			using (var writer = new StreamWriter(stream, new UTF8Encoding(true)))
			{
				writer.WriteLine("HelloПривет");
			}
		}
