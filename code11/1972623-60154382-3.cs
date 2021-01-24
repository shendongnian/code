csharp
void Main()
{
	using (var reader = new StreamReader(@"C:\temp\csvHelper.csv"))
	{
		IEnumerable<IEnumerable<MyClass>> setOfSets = ReadCSVCollection<MyClass>(reader);
	}
}
public static IEnumerable<IEnumerable<T>> ReadCSVCollection<T>(StreamReader reader, bool hasHeader = true)
{
	StringBuilder buffer = new StringBuilder();
	string header = hasHeader ? reader.ReadLine() : null;
	
	while (!reader.EndOfStream)
	{
		string line = reader.ReadLine();
		if (line.Trim() == string.Empty)
		{
			yield return ReadCSVString<T>(buffer.ToString());
			buffer = new StringBuilder();
			continue;
		}
		buffer.AppendLine(line);
	}
	
	yield return ReadCSVString<T>(buffer.ToString());
}
public static IEnumerable<T> ReadCSVString<T>(string input, bool hasHeader = false)
{
	using (StringReader sr = new StringReader(input))
	using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
	{
		csv.Configuration.HasHeaderRecord = hasHeader;
		return csv.GetRecords<T>().ToList();
	}
}
public class MyClass
{
	[CsvHelper.Configuration.Attributes.Index(0)]
	public int ID { get; set; }
	[CsvHelper.Configuration.Attributes.Index(1)]
	public bool Boo { get; set; }
	[CsvHelper.Configuration.Attributes.Index(2)]
	public string Soo { get; set; }
}
// Define other methods and classes here
