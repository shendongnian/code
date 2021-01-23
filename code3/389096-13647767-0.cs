	class Program
	{
		static void Main(string[] args)
		{
			decimal one = 1m;
 
			PrintBytes(one);
			PrintBytes(one + 0.0m);
			PrintBytes(1m + 0.0m);
 
			Console.ReadKey();
		}
 
		public static void PrintBytes(decimal d)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			
			binaryWriter.Write(d);
			
			byte[] decimalBytes = memoryStream.ToArray();
 
			Console.WriteLine(BitConverter.ToString(decimalBytes) + " (" + d + ")");
		}
	}
