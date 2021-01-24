    private void Completed(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            Console.WriteLine("success");
        }
        else
        {
            if (OnFileDownloaded != null) { }
            Console.WriteLine("fail");
        }
    }
