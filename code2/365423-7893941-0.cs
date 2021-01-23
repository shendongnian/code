    WebRequest request = BuildRequest();
    Stopwatch sw = Stopwatch.StartNew();
    using (WebResponse response = request.GetResponse())
    {
        // Potentially fetch all the data here, in case it's streaming...
    }
    sw.Stop();
    Console.WriteLine("Request took {0}", sw.Elapsed);
