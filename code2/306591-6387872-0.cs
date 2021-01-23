    // Requires .NET 3.5
    private void RemoveDuplicate(string sourceFilePath, string destinationFilePath)
    {
        var readLines = File.ReadAllLines(sourceFilePath, Encoding.Default);
        File.WriteAllLines(destinationFilePath, readLines.Distinct().ToArray(), Encoding.Default);
    }
