    using (var storageFile = IsolatedStorageFile.GetUserStoreForApplication())
    using (var stream = new IsolatedStorageFileStream(fileName, FileMode.Open, storageFile))
    {
        if (stream.Length > 0)
        {
            var serializer = new DataContractSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        } 
        else 
        {
            return new T();
        }
    }
