    using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
    {
        using (IsolatedStorageFileStream stream = store.OpenFile("somepic.jpg", FileMode.Open))
        {
            // do something with the stream
        }
    }
