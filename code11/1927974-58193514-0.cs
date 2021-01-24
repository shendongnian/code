Json length: characters=2181, bytes=2181
gzipped.Length=437
class Program
{
  public class Houses
  {
    public int Id { get; } // Btw. No need for setters
    public int People { get; } 
    public Houses(int id, int people)
    {
      Id = id;
      People = people;
    }
  }
  static void Main(string[] args)
  {
    var houses = new List<Houses>();
    for (int i = 0; i < 100; i++)
      houses.Add(new Houses(i, i));
    var json = Newtonsoft.Json.JsonConvert.SerializeObject(houses);
    byte[] inputBytes = Encoding.UTF8.GetBytes(json);
    Console.WriteLine($"Json length: characters={json.Length}, bytes={inputBytes.Length}");
    byte[] gzipped;
    using (var outputStream = new MemoryStream())
    {
      using (var gZipStream = new GZipStream(outputStream, CompressionMode.Compress))
      {
        gZipStream.Write(inputBytes, 0, inputBytes.Length);
      }
      gzipped = outputStream.ToArray();
       
    }
    Console.WriteLine($"gzipped.Length={gzipped.Length}");
  }
}
