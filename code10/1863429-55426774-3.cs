    private static void Main()
    {
        // Generate 5000 lines to write
        var fileLines = Enumerable.Range(0, 5000).Select(i => $"Line number {i}").ToList();
        // File path with base file name
        var filePath = @"f:\public\temp\temp.csv";
        // This should create 10 files
        FileWriterHelper.WriteLinesToFile(filePath, 
            "HEADER: This should be the first line in each file.", fileLines, 500);
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
