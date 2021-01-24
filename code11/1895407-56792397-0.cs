csharp
public class Program
{
    public static void Main(string[] args)
    {
        using (MemoryStream stream = new MemoryStream())
        using (StreamWriter writer = new StreamWriter(stream))
        using (StreamReader reader = new StreamReader(stream))
        using (CsvReader csv = new CsvReader(reader))
        {
            writer.WriteLine("FIRSTNAME;CSN;TYPE");
            writer.WriteLine("Jerome;12345;1");
            writer.Flush();
            stream.Position = 0;
            csv.Configuration.Delimiter = ";";
            csv.Configuration.RegisterClassMap<EmployeeMap>();
            var records = csv.GetRecords<Employee>().ToList();
        }
    }
}
public class Employee
{  
    public string FirstName { get; set; }
    public List<Badge> Badge { get; set; }
}
public class Badge
{
    public long CSN { get; set; }
    public int EmployeeId { get; set; }
    public int Type { get; set; }
}
public class EmployeeMap: ClassMap<Employee>
{
    public EmployeeMap()
    {
        Map(m => m.FirstName).Name("FIRSTNAME");
        Map(m => m.Badge).ConvertUsing(row =>
        {
            var list = new List<Badge>
            {
                new Badge { CSN = row.GetField<long>("CSN"), Type = row.GetField<int>("TYPE") },
            };
            return list;
        });
    }
}
