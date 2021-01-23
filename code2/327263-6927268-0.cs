    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
    {
        string toDelete = "";
        string toCreate = "";
        foreach (var fileName in store.GetFileNames())
        {
            if (fileName.StartsWith("alarm"))
            {
                int counter = 0;
                if (fileName.Length > 5)
                {
                    counter = int.Parse(fileName.Substring(5));
                }
                toDelete = fileName;
                toCreate = "alarm" + ++counter;
                break;
            }
        }
        store.DeleteFile(toDelete);
        store.CreateFile(toCreate);
    }
