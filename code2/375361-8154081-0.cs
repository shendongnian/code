    public static void SaveDataToIsolatedStorage(string filePath, FileMode fileMode, XDocument xDoc)
            {
                using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream location = new IsolatedStorageFileStream(filePath, fileMode, storage))
                    {
                        System.IO.StreamWriter file = new System.IO.StreamWriter(location);
                        xDoc.Save(file);
                    }
                }
            }
