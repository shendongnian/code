    static void CopyFolder(string path, string target)
    {
        // Create target directory
        Directory.CreateDirectory(target);
        // Copy all files
        foreach (string file in Directory.GetFiles(path))
            File.Copy(file, Path.Combine(target, Path.GetFileName(file)));
        // Recursively copy all subdirectories
        foreach (string directory in Directory.GetDirectories(path))
            CopyFolder(directory, Path.Combine(target, Path.GetFileName(directory)));
    }
