    WebClient client = new WebClient();
    client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
    client.OpenReadAsync(new Uri("IMAGE_URL"));
    
    void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
    
        using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("image.jpg", System.IO.FileMode.Create, file))
        {
            byte[] buffer = new byte[1024];
            while (e.Result.Read(buffer, 0, buffer.Length) > 0)
            {
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
