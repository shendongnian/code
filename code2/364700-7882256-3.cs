    static void Main(string[] args)
    {
        var xmlFiles = new BlockingCollection<string>();
    
        // Add some xml files....
    
        SpawnThreads(5, () =>
        {
            using (var web = new WebClient())
            {
                web.UploadFile(xmlFiles.Take());
            }
        });
    
        Console.WriteLine("Done");
        Console.ReadKey();
    }
