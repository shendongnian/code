    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
    {
        int highestNumberFound = -1;
        foreach (var fileName in store.GetFileNames())
        {
            if (fileName.StartsWith("alarm"))
            {
                if (fileName == "alarm")
                {
                    if (highestNumberFound < 0)
                    {
                        highestNumberFound = 0;
                    }
                }
                else if (fileName.Length > 5)
                {
                    int numb;
                    if (int.TryParse(fileName.Substring(5), out numb))
                    {
                        if (numb > highestNumberFound)
                        {
                            highestNumberFound = numb;
                        }
                    }
                }
            }
        }
        string toCreate = "alarm";
        if (++highestNumberFound > 0)
        {
            toCreate += highestNumberFound.ToString();
        }
        store.CreateFile(toCreate);
    }
