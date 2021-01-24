    public static void Main()
    {
        using (var stream = new MemoryStream())
        using (var reader = new StreamReader(stream))
        using (var writer = new StreamWriter(stream))
        using (var jsonWriter = new JsonTextWriter(writer))
        {
            new JsonSerializer().Serialize(jsonWriter, new { name = "Jamie" });
            
            jsonWriter.Flush();
            stream.Position = 0;
            
            Console.WriteLine("stream contents: (" + reader.ReadToEnd() + ")");
        }
    }
