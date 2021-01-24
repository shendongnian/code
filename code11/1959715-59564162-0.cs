csharp
public class Program
{
    public static void Main(string[] args)
    {
        using (MemoryStream stream = new MemoryStream())
        using (StreamWriter writer = new StreamWriter(stream))
        using (StreamReader reader = new StreamReader(stream))
        using (CsvReader csv = new CsvReader(reader, new Configuration()))
        {
            writer.WriteLine("FrameNO,Y,Intensity,Column4,Column5,Column6,Column7,Column8,Column9");
            writer.WriteLine("1,1.123,10,four,five,six,seven,eight,nine");
            writer.WriteLine("2,2.345,20,four,five,six,seven,eight,nine");
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
One thing you might try is setting your delimiter.  Your cultural default might not be a comma.
csharp
csv.Configuration.Delimiter = ",";
