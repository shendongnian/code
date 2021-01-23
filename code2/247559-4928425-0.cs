    static bool inEdit;
    static void FileChanged (object o, FileSystemEventArgs e)
    {
        if (inEdit)
            return;
        inEdit = true;
        // Do processing
        inEdit = false;
    }
