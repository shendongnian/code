    public void DownloadForm1()
    {
       using (var m = new Mutex(true, "SomeAwesomeName"))
       {
          m.WaitOne();
    
          try
          {
             // code to protect here
          }
          finally
          {
             m.ReleaseMutex();
          }
       }
    }
