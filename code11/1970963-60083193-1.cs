csharp
void Main()
{
	short[] values = new short[] {
		1, 999, 200, short.MinValue, short.MaxValue
	};
	
	WriteShortArray(values, @"C:\temp\shorts.txt");
	
	foreach (var shortInfile in ReadShortArray(@"C:\temp\shorts.txt"))
	{
		Console.WriteLine(shortInfile);
	}
}
public static void WriteShortArray(short[] values, string path)
{
	using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
	{
		using (BinaryWriter bw = new BinaryWriter(fs))
		{
			foreach (short value in values)
			{
				bw.Write(value);
			}
		}
	}
}
public static IEnumerable<short> ReadShortArray(string path)
{
	using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
	using (BinaryReader br = new BinaryReader(fs))
	{
		byte[] buffer = new byte[2];
		while (br.Read(buffer, 0, 2) > 0)
			yield return (short)(buffer[0]|(buffer[1]<<8));	}
}
// Define other methods and classes here
