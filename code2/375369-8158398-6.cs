    using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
    {
        using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("myfile.xml", System.IO.FileMode.Create, isf))
        {
            doc.Save(stream);
        }
    }
    using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
    {
        using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("myfile.xml", System.IO.FileMode.Open, isf))
        {
            doc = XDocument.Load(stream);
        }
    }
