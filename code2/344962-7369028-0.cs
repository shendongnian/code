    void RecursiveListFolder(Folder folder, int indent = 0)
    {
        clientContext.Load(folder.Folders);
        clientContext.ExecuteQuery();
        foreach (Folder folder in folder.Folders)
        {
            Console.WriteLine(new string(' ', indent) + folder.Name);
            RecursiveListFolder(folder, indent + 1);
        }
        clientContext.Load(folder.Files);
        clientContext.ExecuteQuery();
        foreach (File file in folder.Files)
        {
            Console.WriteLine(new string(' ', indent) + file.Name);
        }
    }
