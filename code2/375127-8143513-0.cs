    void DeleteFolder(string folder) {
        string[] folders = System.IO.Directory.GetDirectories(folder, "*.*", System.IO.SearchOption.AllDirectories);
        foreach (var directory in folders)
        {
            DeleteFolder(directory);
        }
        //delete this folder if empty
    }
