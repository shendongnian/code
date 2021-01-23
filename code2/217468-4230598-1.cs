    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
    {
        using (var isfs = new IsolatedStorageFileStream(VIEW_MODEL_STORAGE_FILE, FileMode.Create, store))
        {
            using (var sw = new StreamWriter(isfs))
            {
                sw.Write(serializedCollectionObject);
                sw.Close();
            }
        }
    }
