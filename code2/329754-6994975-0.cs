    public static IEnumerable<string> GetFiles(string path, string pattern)
    {
        IEnumerable<string> result;
        try
        {
            result = Directory.GetFiles(path, pattern);
        }
        catch (UnauthorizedAccessException)
        {
            result = new string[0];
        }
        IEnumerable<string> subDirectories;
        try
        {
            subDirectories = Directory.EnumerateDirectories(path);
        }
        catch (UnauthorizedAccessException)
        {
            subDirectories = new string[0];
        }
        foreach (string subDirectory in subDirectories)
        {
            IEnumerable<string> subFiles = GetFiles(subDirectory, pattern);
            result = result.Concat(subFiles); //This is LINQ concatenation
        }
        return result;
    }
    static void Main(string[] args)
    { 
        string startFolder = @"c:\";
        foreach (string fileName in GetFiles(startFolder, "*.chm"))
        {
            Console.WriteLine(fileName);
        }
