    public static string GetUniqueFileName(string rootDirectory)
    {
        if (rootDirectory == null)
        {
            throw new ArgumentNullException("rootDirectory");
        }
        if (!Directory.Exists(rootDirectory))
        {
            throw new DirectoryNotFoundException();
        }
        string tempFileAddress = null;
        do
        {
            tempFileAddress = System.IO.Path.Combine(rootDirectory, System.IO.Path.GetRandomFileName().Replace(".", ""));
        } while (System.IO.File.Exists(tempFileAddress) || System.IO.Directory.Exists(tempFileAddress));
        return tempFileAddress;
    }
