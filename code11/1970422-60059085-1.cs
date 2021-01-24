csharp
using (MemoryStream stream = new MemoryStream())
using (StreamWriter writer = new StreamWriter(stream))
using (StreamReader reader = new StreamReader(stream))
using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    writer.WriteLine("Id,Name,Column3,Column4,Column5");
    writer.WriteLine("1,One,Item1,Item2,Item3");
    writer.WriteLine("2,Two,Item4,Item5,Item6");
    writer.Flush();
    stream.Position = 0;
    reader.BaseStream.Position = 0;
    csv.Read();
    csv.ReadHeader();
    string[] header = csv.Context.HeaderRecord;
    var columnExtracted = "Column3";
    int extractedIndex = Array.IndexOf(header, columnExtracted);
    while (csv.Read())
    {
        string[] row = csv.Context.Record;
        var column = row[extractedIndex];
        Console.WriteLine(column);
    }
}
Console.ReadKey();
