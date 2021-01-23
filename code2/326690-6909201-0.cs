    WebClient client = new WebClient();
    client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
    client.OpenReadAsync(new Uri("your_URL"));
    
    
    void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        var file = IsolatedStorageFile.GetUserStoreForApplication();
    
        using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("file.epub", System.IO.FileMode.Create, file))
        {
            byte[] buffer = new byte[1024];
            while (e.Result.Read(buffer, 0, buffer.Length) > 0)
            {
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
