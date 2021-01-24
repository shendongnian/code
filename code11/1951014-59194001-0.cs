    static IEnumerable<string> EnumerateFiles(string path, string partNumber)
    {
        return Enumerable.Concat(
            Directory.EnumerateFiles(path, partNumber + ".jpg"),
            Directory.EnumerateFiles(path, partNumber + "_*.jpg"));
    }
