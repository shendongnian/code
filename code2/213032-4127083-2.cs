    using (IsolatedStorageFile currentIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
    {
        using (var img = currentIsolatedStorage.OpenFile(fileName, FileMode.Open))
        {
            var imgStream = new MemoryStream(img.Length);
            var buffer = new byte[Math.Min(1024, img.Length)];
            int read;
            while ((read = img.Read(buffer, 0, buffer.Length)) != 0)
                imgStream.Write(buffer, 0, read);
            return imgStream;
        }
    }
