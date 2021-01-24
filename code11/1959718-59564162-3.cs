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
            writer.WriteLine("FrameNO,Column2,Y,Column4,Column5,Column6,Intensity,Column8,Column9");
            writer.WriteLine("1,two,1.123,four,five,six,10,eight,nine");
            writer.WriteLine("2,two,2.345,four,five,six,20,eight,nine");
            writer.Flush();
            stream.Position = 0;
            var records = csv.GetRecords<Foo>();
            foreach (var Foo in records)
            {
                Console.WriteLine(Foo.FrameNO);
            }
        }
        Console.ReadLine();
    }
}
public class Foo
{
    public int FrameNO { get; set; }
    public double Y { get; set; }
    public int Intensity { get; set; }
}
One thing you might try is setting your delimiter.  Your cultural default might not be a comma. Also, if you have spaces between your data and the commas, you will need to set the `TrimOptions`.
csharp
using (var csv = new CsvReader(reader))
{
    csv.Configuration.Delimiter = ",";
    csv.Configuration.TrimOptions = TrimOptions.Trim;
    var records = csv.GetRecords<Foo>();
