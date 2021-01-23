    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
    {
        if (!store.FileExists(VIEW_MODEL_STORAGE_FILE))
        {
            return result;
        }
        using (var isfs = new IsolatedStorageFileStream(VIEW_MODEL_STORAGE_FILE, FileMode.Open, store))
        {
            using (var sr = new StreamReader(isfs))
            {
                string lineOfData;
                while ((lineOfData = sr.ReadLine()) != null)
                {
                    result += lineOfData;
                }
            }
        }
    }
