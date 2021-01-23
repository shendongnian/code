    static ManualResetEvent resetEvent = new ManualResetEvent(false);
    static void Main()
    {
         CallAsyncMethod();
         resetEvent.WaitOne(); // Blocks until "set"
    }
    void DownloadDataCallback()
    {
         // Do your processing on completion...
         resetEvent.Set(); // Allow the program to exit
    }
