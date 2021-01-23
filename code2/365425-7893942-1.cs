    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);
    System.Diagnostics.Stopwatch timer = new Stopwatch();
    timer.Start();
    
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    response.Close ();
    timer.Stop();
    
    TimeSpan timeTaken = timer.Elapsed;
