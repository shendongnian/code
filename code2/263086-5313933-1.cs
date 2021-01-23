    private static string RenameFolder(string path, string newFolderName)
    {
        DirectoryInfo parent = Directory.GetParent(path);
        String newPath = Path.Combine(parent.FullName, newFolderName);
        // rename to some temp name, to help change lower and uppercast names
        Directory.Move(path, newPath + "__renameTemp__");
        Directory.Move(newPath + "__renameTemp__", newPath);
        return newPath;
    }
