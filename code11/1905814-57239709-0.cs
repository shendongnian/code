    public static void ProcessFile(string path)
    {
        string folder = Path.GetDirectoryName(path);
        string file = Path.GetFileName(path);
        // Keep the first 6 characters from the source file?
        string newFile = file.Substring(0, 6) + " hrefcount.txt";
        string newPath = Path.Combine(folder, newFile);
        // A single line to retrieve your counter thanks to IEnumerables and Linq
        int counter = File.ReadLines(path).Count(x => x.Contains("href="));
        // Create, but dispose also the file
        using (var fileCreated = File.CreateText(newPath))
        {
            fileCreated.WriteLine("The number of times href appears is " + counter);
        }
        // Now you should be free to delete the file
        File.Delete(newPath);
    }
