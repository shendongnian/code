csharp
void Main()
{
	var data = new List<List<MyClass>> {
		new List<MyClass> {
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} },
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} }
		},
		new List<MyClass> {
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} },
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} }
		},
		new List<MyClass> {
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} },
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} },
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} }
		},
		new List<MyClass> {
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} },
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} },
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} },
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} }
		},
		new List<MyClass> {
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} },
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} },
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} },
			{ new MyClass {ID = 0, Boo = true, Soo = "qwerty"} }
		},
	};
	using (var reader = new StreamReader(@"C:\temp\csvHelper.csv"))
	{
		ReadCSVCollection<MyClass>(reader).Dump();
	}
}
public static IEnumerable<IEnumerable<T>> ReadCSVCollection<T>(StreamReader reader, bool hasHeader = true)
{
	List<T> resultSet = new List<T>();
	string header = hasHeader ? reader.ReadLine() : null;
	while (!reader.EndOfStream)
	{
		string line = reader.ReadLine();
		if (line.Trim() == string.Empty)
		{
			yield return resultSet;
			resultSet = new List<T>();
			continue;
		}
		using (StringReader sr = new StringReader(line))
		using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
		{
			csv.Configuration.HasHeaderRecord = false;
			resultSet.AddRange(csv.GetRecords<T>());
		}
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
