csharp
public class PersonCustomer1 : IPerson
{
    [Index(0)]
    public string Name { get; set; }
    [Index(1)]
    public string LastName { get; set; }
    [Index(3)]
    public int Age { get; set; }
}
public class PersonCustomer2 : IPerson
{
    [Index(2)]
    public string Name { get; set; }
    [Index(1)]
    public string LastName { get; set; }
    [Index(0)]
    public int Age { get; set; }
    [Index(3)]
    public int Gender { get; set; }
}
public class ConverterCsv<T>
{
    public IEnumerable<T> Convert(FileInfo fileInfo)
    {
        IEnumerable<T> records = new List<T>();
        using (var reader = fileInfo.OpenText())
        using (var csv = new CsvReader(reader))
        {
            csv.Configuration.HasHeaderRecord = false;
            records = csv.GetRecords<T>().ToList();
        }
        return records;
    }
}
