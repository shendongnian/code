    private static volatile int activeThreads = 0;
    
    public static void RecordData()
    {
      var nbThreads = 10;
      var source = db.ListOfUrls; // Thousands urls
      var iterations = source.Length / groupSize; 
      for (int i = 0; i < iterations; i++)
      {
        var subList = source.Skip(groupSize* i).Take(groupSize);
        Parallel.ForEach(subList, (item) => RecordUri(item)); 
        //I want to wait here until process further data to avoid overload
        while (activeThreads > 30) Thread.Sleep(100);
      }
    }
    private static async Task RecordUri(Uri uri)
    {
       using (WebClient wc = new WebClient())
       {
          Interlocked.Increment(ref activeThreads);
          wc.DownloadStringCompleted += (sender, e) => Interlocked.Decrement(ref iterationsCount);
          var jsonData = "";
          RootObject root;
          jsonData = await wc.DownloadStringTaskAsync(uri);
          var root = JsonConvert.DeserializeObject<RootObject>(jsonData);
          RecordData(root)
        }
    }
