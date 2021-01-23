    private static string RemoveDuplicate(string sourceFilePath, string destinationFilePath)
    {
        var readLines = File.ReadAllLines(sourceFilePath, Encoding.Default);
        var result = readLines.Distinct().ToArray();
        File.WriteAllLines(destinationFilePath, result, Encoding.Default);
        return string.Join(Environment.NewLine, result);
    }
