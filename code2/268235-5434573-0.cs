    public void GetImage(string fileName, Action<Bitmap> onGetImage) 
    { 
        lock(Cache) 
        { 
            if (Cache.ContainsKey(fileName)) 
            { 
                onGetImage(Cache[fileName]); 
            } 
            else if (downloadingCollection.contains(fileName))
            {
                while (!Cache.ContainsKey(fileName))
                {
                    System.Threading.Monitor.Wait(Cache)
                }
                onGetImage(Cache[fileName]); 
            }
            else 
            { 
               var server = new Server(); 
               downloadCollection.Add(filename);
               server.ImageDownloaded += (s, e) => 
               { 
                  lock (Cache)
                  {
                      downloadCollection.Remove(filename);
                      Cache.Add(e.Bitmap, e.Name); 
                      System.Threading.Monitor.PulseAll(Cache);
                  }
                  onGetImage(e.Bitmap);
                                     
               } 
               server.DownloadImageAsync(fileName, onGetImage); // last arg is just passed to the handler 
            } 
        } 
    }
