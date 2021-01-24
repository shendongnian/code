csharp
public static void Main(string[] args)
{
    using (var reader = new StreamReader(@"C:\Users\me\Documents\file.csv"))
    using (var csv = new CsvReader(reader))          
    {
        csv.Configuration.PrepareHeaderForMatch = (string header, int index) =>
            header.Replace(" ", "_").Replace("(", "").Replace(")", "").Replace(".", "");
        csv.Configuration.RegisterClassMap<TaskEntityMap>();
        var records = csv.GetRecords<TaskEntity>().ToList();
    }
}
public class TaskEntity
{
    public int Id { get; set; }
    public string SqlTableColumn1 { get; set; }
    public string SqlTableColumn2 { get; set; }
}
public sealed class TaskEntityMap : ClassMap<TaskEntity>
{
    public TaskEntityMap()
    {
        Map(m => m.SqlTableColumn1).Name("CsvColumn1");
        Map(m => m.SqlTableColumn2).ConvertUsing(row => row.GetField<string>("CsvColumn2") + " " + row.GetField<string>("CsvColumn3"));
    }
}
