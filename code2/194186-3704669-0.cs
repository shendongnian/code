    using(IsolatedStorageFile store = IsolatedStorageFile.GetMachineStoreForApplication())
    {
        // check if file exists or not
        try
        {
            using(IsolatedStorageFileStream isfs = new IsolatedStorageFileStream(STG_FILE_NAME, FileMode.OpenOrCreate, store)) {
                StreamWriter sw = new StreamWriter(isfs);
                foreach(string key in m_values.Keys) {
                    sw.WriteLine(key + "::" + m_values[key]);
                } // foreach
                sw.Flush();
            } // using
        } catch(IOException) {
            // generally because file is locked by another process...do nothing
        }
    } // using
