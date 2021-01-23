    private void wc_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            if (e.Error is WebException)
                Console.WriteLine("Web Exception {0}", ((WebException)e.Error).Message);
            else
                Console.WriteLine("Web Exception {0}", e.Error.Message);
        }
        else if (e.Cancelled)
            Console.WriteLine("File cancelled");
        else
            Console.WriteLine("File completed");
    } 
