    using (MemoryStream stream = new MemoryStream())
    {
        byte[] contents = new byte[1024];
        int bytes;
    
        while ((bytes = e.ChosenPhoto.Read(contents, 0, contents.Length)) > 0)
        {
            stream.Write(contents, 0, bytes);
        }
    
        using (var local = new IsolatedStorageFileStream("myImage.jpg", FileMode.Create, IsolatedStorageFile.GetUserStoreForApplication()))
        {
            local.Write(stream.GetBuffer(), 0, stream.GetBuffer().Length);
        }
    }
