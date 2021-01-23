    static void Main(string[] args)
    {
        var urlXML = new BlockingCollection<Tuple<string, string>>();
        urlXML.Add(Tuple.Create("http://someurl.com", "filename"));
    
        // Add some more to collection...
    
        SpawnAsyncs(5, c =>
        {
            using (var web = new WebClient())
            {
                var current = urlXML.Take();
    
                web.UploadFileCompleted += (s, e) =>
                {
                    // some code to mess with e.Result (response)
                    c.Signal();
                };
    
                web.UploadFileAsyncAsync(new Uri(current.Item1), current.Item2);
            }
        });
    
        Console.WriteLine("Done");
        Console.ReadKey();
    }
