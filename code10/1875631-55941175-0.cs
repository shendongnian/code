csharp
public static void Main(string[] args)
{
    using (MemoryStream stream = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(stream))
    using (StreamReader reader = new StreamReader(stream))
    using (CsvReader csv = new CsvReader(reader))
    {
        writer.WriteLine("A,B,B");
        writer.WriteLine("a,b1,b2");
        writer.Flush();
        stream.Position = 0;
        var myMap = new MyCsvMap();
                    
        csv.Configuration.RegisterClassMap(myMap);
        var records = csv.GetRecords<MyCsv>().ToList();
    }    
}
public class MyCsv
{
    public string A { get; set; }
    public List<string> Bs { get; set; }
}
public class MyCsvMap : ClassMap<MyCsv>
{
    public MyCsvMap()
    {
        Map(m => m.A);
        Map(m => m.Bs).ConvertUsing(row => {
            var result = new List<string>();
            var headers = row.Context.HeaderRecord;
            for (var i = 0; i < headers.Length; i++)
            {
                if (headers[i] == "B")
                {
                    result.Add(row.GetField(i));
                }
            }
            return result;
        });
    }
}
