    public static string GetUniqueFileName(string rootDirectory, string extension)
    {
        if (rootDirectory == null)
        {
            throw new ArgumentNullException("rootDirectory");
        }
        if (!Directory.Exists(rootDirectory))
        {
            throw new DirectoryNotFoundException();
        }
        string fileName = null;
        do
        {
            fileName = System.IO.Path.Combine(rootDirectory, System.IO.Path.GetRandomFileName().Replace(".", ""));
            fileName = System.IO.Path.ChangeExtension(fileName, extension);
        } while (System.IO.File.Exists(fileName) || System.IO.Directory.Exists(fileName));
        return fileName;
    }
