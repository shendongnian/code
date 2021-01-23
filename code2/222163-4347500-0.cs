    public static string GetValidFilename(string fileNameCandidate)
    {
        var invalids = Path.GetInvalidFileNameChars();
        var validName = fileNameCandidate.Where(c => !invalids.Contains(c))
                                         .ToArray();
        return new string(validName);
    }
