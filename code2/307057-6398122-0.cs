    private static string RemoveDuplicate(string sourceFilePath, string destinationFilePath)
    {
    var readLines = File.ReadAllLines(sourceFilePath, Encoding.Default);
    var result = readLines.Distinct().ToArray();
    string resultString =  String.Join(",",ids);
    File.WriteAllLines(destinationFilePath, result, Encoding.Default);
    return resultString;
    }
