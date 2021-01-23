    var oldName = "file.old"; var newName = "file.new";
    
    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
    {
        using (var readStream = new IsolatedStorageFileStream(oldName, FileMode.Open, store))
        using (var writeStream = new IsolatedStorageFileStream(newName, FileMode.Create, store))
        using (var reader = new StreamReader(readStream))
        using (var writer = new StreamWriter(writeStream))
        {
            writer.Write(reader.ReadToEnd());
        }
    
        store.DeleteFile(oldName); 
    }
