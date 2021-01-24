    Stopwatch sw = new Stopwatch();
    sw.Start();
    
    var collection = Regex.Matches(targetString, pattern, RegexOptions.Multiline | RegexOptions.ExplicitCapture);
    
    int count = collection.Count; // Force immediate evaluation
    sw.Stop();
    Console.WriteLine("Found {0}, Elapsed={1}", count, sw.Elapsed);
