    public static void SpawnThreads(List<string> imageList)
    { 
      imageList = new List<string>(imageList); 
      var finished = new CountdownEvent(1);
      var picDownloaders = new PicDownloader[imageList.Count]; 
      ThreadPool.SetMaxThreads(MaxThreadCount, MaxThreadCount); 
      for (int i = 0; i < imageList.Count; i++) 
      { 
        finished.AddCount();    
        PicDownloader p = new PicDownloader(imageList[i]); 
        picDownloaders[i] = p; 
        ThreadPool.QueueUserWorkItem(
          (state) =>
          {
            try
            {
              p.DoAction
            }
            finally
            {
              finished.Signal();
            }
          });
      } 
      finished.Signal();
      finished.Wait();
      Console.WriteLine("All pics downloaded"); 
    } 
