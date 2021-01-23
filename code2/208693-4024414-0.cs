    public static void SaveLog(string data)
            {
                using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream(fileName, FileMode.Append, FileAccess.Write, isf))
                    {
                        using (StreamWriter sw = new StreamWriter(isfs))
                        {
                            try
                            {
                                sw.Write(data);
    
                            }
                            finally
                            {
                                sw.Close();
                            }
                        }
                    }
                }
            }
