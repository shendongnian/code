csharp
public static void Main(string[] args)
{        
    using (MemoryStream stream = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(stream))
    using (StreamReader reader = new StreamReader(stream))
    using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        writer.WriteLine("ID,Boo,Soo");
        writer.WriteLine("0,True,\"Test\nqwerty\"");
        writer.WriteLine("0,True,qwerty");
        writer.WriteLine("");
        writer.WriteLine("0,True,qwerty");
        writer.Flush();
        stream.Position = 0;
        csv.Configuration.IgnoreBlankLines = false;
        csv.Read();
        csv.ReadHeader();
        var data = new List<List<MyClass>>();
        var resultSet = new List<MyClass>();
        while (csv.Read())
        {
            if (csv.Context.RawRecord.Trim() == string.Empty)
            {
                data.Add(resultSet);
                resultSet = new List<MyClass>();
                continue;
            }
            var record = csv.GetRecord<MyClass>();
            resultSet.Add(record);
        }
        if (resultSet.Count > 0)
        {
            data.Add(resultSet);
        }
    } 
    Console.ReadKey();
}
