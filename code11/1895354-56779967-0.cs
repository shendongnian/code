    void Main()
    {
        string webData = "[{\"date\":\"01/01/2018\",\"name\":\"toto\"}]";
        var records = JsonConvert.DeserializeObject<IList<JournalImport>>(webData, new Newtonsoft.Json.Converters.IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
        using (var writer = new System.IO.StreamWriter(File.Create(@"toto.csv")))
        using (var csv = new CsvHelper.CsvWriter(writer))
        {
            csv.Configuration.TypeConverterCache.AddConverter<DateTime>(new DateTimeCOnverter());
            csv.WriteRecords(records);
        }
    }
    
    public class JournalImport
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
    
    public class DateTimeCOnverter : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            throw new NotImplementedException();
        }
    
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is DateTime date)
            {
                return date.ToString("dd/MM/yyyy");
            }
            return value?.ToString();
        }
    }
