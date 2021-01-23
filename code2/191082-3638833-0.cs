    using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForAssembly())
    {
        //write sample file
        using (Stream fs = new IsolatedStorageFileStream("test.txt", FileMode.Create, store))
        {
            StreamWriter w = new StreamWriter(fs);
            w.WriteLine("test");
            w.Flush();
        }
        //the following line will crash...
        //store.CopyFile("test.txt", @"c:\test2.txt");
        //open the file backup, read its contents, write them back out to 
        //your new file.
        using (IsolatedStorageFileStream ifs = store.OpenFile("test.txt", FileMode.Open))
        {
            StreamReader reader = new StreamReader(ifs);
            string contents = reader.ReadToEnd();
            using (StreamWriter sw = new StreamWriter("nonisostorage.txt"))
            {
                sw.Write(contents);
            }
        }
    }
