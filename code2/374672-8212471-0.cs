    WebClient client = new WebClient ();
    // Add a user agent header in case the 
    // requested URI contains a query.
    client.Headers.Add ("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    Stream data = client.OpenRead (@"your-url-here");
    StreamReader reader = new StreamReader (data);
    string s = reader.ReadToEnd();
 
    stopwatch.Stop();
    Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
    data.Close();
    reader.Close();
