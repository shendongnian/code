    public static void DeleteDirectoryRecursive(this IsolatedStorageFile isf, string dir)
    {
        foreach (var file in isf.GetFileNames(dir))
        {
            isf.DeleteFile(dir + file);
        }
        foreach (var subdir in isf.GetDirectoryNames(dir))
        {
            isf.DeleteDirectoryRecursive(dir + subdir + "\\");
        }
        isf.DeleteDirectory(dir.TrimEnd('\\'));
    }
