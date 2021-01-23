    using (Stream stream = new IsolatedStorageFileStream("somefilename.ext", FileMode.Create, FileAccess.Write, IsolatedStorageFile.GetUserStoreForApplication()))
    {
        // Use the stream normally in a TextWriter
        using (TextWriter writer = new StreamWriter(stream, Encoding.UTF8))
        {
            writer.Flush();
            writer.Close();
        }
    
        stream.Close();
    }
