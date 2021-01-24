    static IEnumerable<string> EnumerateFiles(string path, string partNumber)
    {
        string fileNameGenericMask = partNumber + "*.jpg";
        string fileNameRegexPattern = "^" + Regex.Escape(partNumber) + @"(_\d+)?$";
        return Directory.EnumerateFiles(path, fileNameGenericMask)
                        .Where(filePath => Regex.IsMatch(Path.GetFileNameWithoutExtension(filePath), fileNameRegexPattern));
    }
