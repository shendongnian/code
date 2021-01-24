csvWriter.Configuration.RegisterClassMap<MyCsvClassMap>();
The rest of your example works fine.
Try the following console app:
class Program
{
	static void Main(string[] args)
	{
		var allRecords = new List<MyCsvClass>()
		{
			new MyCsvClass { DbId = "1", Data1 = "data1", Data2 = "data2"}
		};
		using (var sw = new StreamWriter("C:\\temp\\test.csv"))
		{
			using (var csvWriter = new CsvHelper.CsvWriter(sw))
			{
				csvWriter.Configuration.RegisterClassMap<MyCsvClassMap>();
				csvWriter.WriteHeader<MyCsvClass>();
				csvWriter.NextRecord();
				csvWriter.WriteRecords(allRecords);
			}
		}
	}
	public class MyCsvClassMap : ClassMap<MyCsvClass>
	{
		public MyCsvClassMap()
		{
			AutoMap();
			Map(m => m.DbId).Ignore();
		}
	}
	public class MyCsvClass
	{
		public string DbId { get; set; }
		public string Data1 { get; set; }
		public string Data2 { get; set; }
	}
}
If this is working there is maybe some other code which causes this behavior.
