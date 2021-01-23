    private static string RenameFolder(string path, string newFolderName)
    {
        DirectoryInfo di = new DirectoryInfo(path);
        DirectoryInfo parent = Directory.GetParent(di.FullName);
        String newPath = Path.Combine(parent.FullName, newFolderName);
        // rename to some temp name, to help change lower and uppercast names
        di.MoveTo(newPath + "__renameTemp__");
        di.MoveTo(newPath);
        return di.FullName;
    }
