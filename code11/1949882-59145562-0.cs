csharp
public class Program
{
    public static void Main(string[] args)
    {
        var flippedRecords = new List<dynamic>();
        using (MemoryStream stream = new MemoryStream())
        using (StreamWriter writer = new StreamWriter(stream))
        using (StreamReader reader = new StreamReader(stream))
        using (CsvReader csv = new CsvReader(reader))
        {
            writer.WriteLine("Name,Foo,Bar");
            writer.WriteLine("Address,Foo's address,Bar's address");
            writer.WriteLine("Age,24,19");
            writer.Flush();
            stream.Position = 0;
            csv.Configuration.HasHeaderRecord = false;
            var records = csv.GetRecords<dynamic>().ToList();
            var rows = new List<IDictionary<string, object>>();                
            foreach (var row in records)
            {
                rows.Add(row as IDictionary<string, object>);
            }
            for (int i = 2; i <= rows[0].Count; i++)
            {
                var flippedRecord = new ExpandoObject() as IDictionary<string, object>;
                foreach (var row in rows)
                {
                    flippedRecord.Add((string)row["Field1"], row["Field" + i]);
                }
                flippedRecords.Add(flippedRecord);
            }
        }
        using (MemoryStream stream = new MemoryStream())
        using (StreamWriter writer = new StreamWriter(stream))
        using (CsvWriter csvWriter = new CsvWriter(writer))
        using (StreamReader reader = new StreamReader(stream))
        using (CsvReader csvReader = new CsvReader(reader))
        {
            csvWriter.WriteRecords(flippedRecords);
            writer.Flush();
            stream.Position = 0;
            csvReader.Configuration.RegisterClassMap<PersonMap>();
            var people = csvReader.GetRecords<Person>().ToArray();
        }
    }
}
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
}
public class PersonMap : ClassMap<Person>
{
    public PersonMap()
    {
        Map(m => m.FirstName).Name("Name");
        Map(m => m.Address);
        Map(m => m.Age);
    }
}
