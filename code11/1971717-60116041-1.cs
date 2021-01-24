csharp
public static void Main(string[] args)
{
    using (MemoryStream stream = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(stream))
    using (StreamReader reader = new StreamReader(stream))
    using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        writer.WriteLine("MF,RefDes,MPN,Value");
        writer.WriteLine("name1,empId1,241682-27638-USD-CIGGNT ,1");
        writer.WriteLine("name2,empId2,241682-27638-USD-OCGGINT ,1");
        writer.WriteLine("name3,empId3,241942-37190-USD-GGDIV ,2");
        writer.WriteLine("name4,empId4,241942-37190-USD-CHYOF ,1");
        writer.Flush();
        stream.Position = 0;
        string[] ReferenceDesignatorAliases = { "Reference Designator", "RefDes", "Designator", "Annotation" };        
        csv.Read();
        csv.ReadHeader();
        var records = new List<string>();
        if (csv.Context.HeaderRecord.Intersect(ReferenceDesignatorAliases).Count() > 0)
        {
            while (csv.Read())
            {
                if (csv.TryGetField(csv.GetFieldIndex(ReferenceDesignatorAliases), out string value))
                {
                    records.Add(value);
                }
            }
        }
    }
    Console.ReadKey();
}
