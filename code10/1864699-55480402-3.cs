    static void Main(string[] args)
    {
        string pathAndFileName = ..your file name...;
        string resultFileName = GetActualCaseForFileName(pathAndFileName);
        using (FileStream fileStream = File.OpenRead(resultFileName))
        {
            Bitmap bitmap = new Bitmap(fileStream);
            Image image = (Image)bitmap;
        }    
    
        Console.WriteLine(resultFileName);
    }
    
    private static string GetActualCaseForFileName(string pathAndFileName)
    {
        string directory = Path.GetDirectoryName(pathAndFileName);
        string pattern = Path.GetFileName(pathAndFileName);
        string resultFileName;
    
        // Enumerate all files in the directory, using the file name as a pattern
        // This will list all case variants of the filename even on file systems that
        // are case sensitive
        IEnumerable<string> foundFiles = Directory.EnumerateFiles(directory, pattern);
    
        if (foundFiles.Any())
        {
            if (foundFiles.Count() > 1)
            {
                // More than two files with the same name but different case spelling found
                throw new Exception("Ambiguous File reference for " + pathAndFileName);
            }
            else
            {
                resultFileName = foundFiles.First();
            }
        }
        else
        {
            throw new FileNotFoundException("File not found" + pathAndFileName, pathAndFileName);
        }
    
        return resultFileName;
    }
