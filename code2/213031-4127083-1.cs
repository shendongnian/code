    using (IsolatedStorageFile currentIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
    {
        using (var img = currentIsolatedStorage.OpenFile(fileName, FileMode.Open))
        {
            var imgStream = new MemoryStream(img.Length);
            img.CopyTo(imgStream);
            return imgStream;
        }
    }
