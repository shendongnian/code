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
public sealed class TaskEntityMap : ClassMap<TaskEntity>
{
    public TaskEntityMap()
    {
        Map(m => m.SqlTableColumn1).ConvertUsing(row => row.GetField<int>(0) == 1 ? 
            row.GetField<string>("CsvColumn1") : 
            row.GetField<string>("CsvColumn4")
            );
        Map(m => m.SqlTableColumn2).ConvertUsing(row => row.GetField<int>(0) == 1 ? 
            row.GetField<string>("CsvColumn2") + " " + row.GetField<string>("CsvColumn3") :
            row.GetField<string>("CsvColumn5") + " " + row.GetField<string>("CsvColumn6")
            );
    }
}
Another option would be to manually construct the `TaskEntity` objects.
csharp
public static void Main(string[] args)
{
    using (var reader = new StreamReader(@"C:\Users\me\Documents\file.csv"))
    using (var csv = new CsvReader(reader))          
    {
        csv.Configuration.PrepareHeaderForMatch = (string header, int index) =>
            header.Replace(" ", "_").Replace("(", "").Replace(")", "").Replace(".", "");
        var records = new List<TaskEntity>();
        csv.Read();
        csv.ReadHeader();
        while (csv.Read())
        {                    
            if (csv.GetField<int>(0) == 1)
            {
                var record = new TaskEntity
                {
                    SqlTableColumn1 = csv.GetField<string>("CsvColumn1"),
                    SqlTableColumn2 = csv.GetField<string>("CsvColumn2") + " " + csv.GetField<string>("CsvColumn3")
                };
                records.Add(record);
            }
            else
            {
                var record = new TaskEntity
                {
                    SqlTableColumn1 = csv.GetField<string>("CsvColumn4"),
                    SqlTableColumn2 = csv.GetField<string>("CsvColumn5") + " " + csv.GetField<string>("CsvColumn6")
                };
                records.Add(record);
            }                    
        }
    }  // Break here.
}
