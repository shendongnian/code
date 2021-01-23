    private object thislock = new Object();
    void UpdateProgress(DownloadProgressChangedEventArgs e)
    {
        lock (thislock)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("\b");
            }
            Console.Write(e.ProgressPercentage.ToString() + "%");
        }
    }
