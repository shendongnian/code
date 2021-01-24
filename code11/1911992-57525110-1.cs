    public class TestModel
    {
        public byte[] Bytes { get; set; }
    }
    public static void Main(string[] args)
    {
        var model = new TestModel() { Bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 } };
        var request = WebRequest.CreateHttp("...");
        request.Method = "POST";
        request.SendChunked = true;
        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        using (var writer = new JsonTextWriter(streamWriter))
        {
            new JsonSerializer().Serialize(writer, model);
        }
        var response = request.GetResponse();
    }
