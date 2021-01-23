    private static void RemoveDuplicate(string sourceFilePath, string destinationFilePath)
    {
        var readLines = File.ReadAllLines(sourceFilePath, Encoding.Default);
        File.WriteAllLines(destinationFilePath, readLines.Distinct().ToArray(), Encoding.Default);
    }
    private static void startremdup(object sender, EventArgs e)
    {
        RemoveDuplicate("C:\test.txt", "C:\test2.txt");
    }
