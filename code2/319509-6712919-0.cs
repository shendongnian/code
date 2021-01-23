    public static void ConcatenateFiles(
        string outputFileName, IEnumerable<string> inputFiles)
    {
        File.WriteAllLines(outputFileName, inputFiles.SelectMany(File.ReadLines));
    }
