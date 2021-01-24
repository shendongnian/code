    public class MyClass
    {
        public int Number { get; set; }
        public Dictionary<string, string> Value { get; set; }
    }
    public class JsonConverter : ITypeConverter
    {
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return JsonConvert.SerializeObject(value);
        }
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
        }
    }
    public class MyClassMap : ClassMap<MyClass>
    {
        public MyClassMap()
        {
            var i = 0;
            Map(m => m.Number).Index(i++);
            Map(m => m.Value).Index(i++).TypeConverter<JsonConverter>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(0, 5).Select(x => new MyClass()
            {
                Number = x,
                Value = new Dictionary<string, string>()
                {
                    {x.ToString(), x + 1.ToString()}
                }
            });
            using (var writer = new StringWriter())
            using (var csv = new CsvWriter(writer)
            {
                Configuration = { HasHeaderRecord = true },
            })
            {
                csv.Configuration.RegisterClassMap<MyClassMap>();
                csv.WriteRecords(list);
                writer.Flush();
                Console.WriteLine(writer.ToString());
            }
        }
    }
