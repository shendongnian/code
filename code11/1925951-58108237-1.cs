    static void Main(string[] args)
    {
        var filePath = @"f:\private\temp\temp2.txt";
        // Declare this outside the 'using' block so we can access it later
        Config config;
        using (var reader = new StreamReader(filePath))
        {
            config = (Config) new XmlSerializer(typeof(Config)).Deserialize(reader);
        }
        Console.WriteLine(config);
        GetKeyFromUser("\n\nDone! Press any key to exit...");
    }
