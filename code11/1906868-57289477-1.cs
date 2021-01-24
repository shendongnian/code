		var input = @"""Id"" , ""Name""    , ""Job""
""1""  , ""Alan""    , ""Engineer""
""2""  , ""Bob""     , ""Technician""
""3""  , ""Charlie"" , """"
""4""  , ""Danny""   , """"";
		
		var records= new List<Foo>();
		
		//reading CSV to List Foo;
		using (TextReader reader = new StringReader(input))
		using (var csvReader = new CsvReader(reader))
		{
			csvReader.Configuration.Delimiter=",";
			csvReader.Configuration.HasHeaderRecord=false; 
			csvReader.Configuration.TrimOptions=TrimOptions.Trim | TrimOptions.InsideQuotes;
			csvReader.Configuration.RegisterClassMap<FooMap>();
			records = csvReader.GetRecords<Foo>().ToList();
		}
		
		records.Dump();
		//Filter
		var result = records.Where(x=> !string.IsNullOrEmpty(x.Job)).ToList();
		result.Dump();
	}
	
	public class Foo
	{
		public string Id { get; set; }
		public string Name { get; set; }		
		public string Job { get; set; }
	}
	public class FooMap : ClassMap<Foo>
	{
		public FooMap()
		{
			Map(m => m.Id).Index(0);
			Map(m => m.Name).Index(1);			
			Map(m => m.Job).Index(2);
            //mapping with column header
			/*Map(m => m.Id).Name("Id");
			Map(m => m.Name).Name("Name");			
			Map(m => m.Job).Name("Job");*/
		}
	}
