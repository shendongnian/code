        public static void UploadDataInBackground (string address, byte[] data)
        {
            WebClient client = new WebClient ();
            Uri uri = new Uri(address);
    
    
            // Specify a progress notification handler.
            client.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressCallback);
            client.UploadDataAsync (uri, "POST", data);
            Console.WriteLine ("Data upload started.");
        }
    private static void UploadProgressCallback(object sender, UploadProgressChangedEventArgs e)
    {
        // Displays the operation identifier, and the transfer progress.
        Console.WriteLine("{0}    uploaded {1} of {2} bytes. {3} % complete...", 
            (string)e.UserState, 
            e.BytesSent, 
            e.TotalBytesToSend,
            e.ProgressPercentage);
    }
