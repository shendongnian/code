    private static FontFamily CreateFontFamily(string path) {
        Uri uri;
        if (!Uri.TryCreate(path, UriKind.Absolute, out uri))
            throw new ArgumentException("Must provide a valid location", "path");
    
        return new FontFamily(uri, string.Empty);
    }
    
    public static IEnumerable<FontFamily> GetNonCachedFontFamilies(string location) {
        if (string.IsNullOrEmpty("location"))
            throw new ArgumentException("Must provide a location", "location");
    
        DirectoryInfo directoryInfo = new DirectoryInfo(location);
        if (directoryInfo.Exists) {
            FileInfo[] fileInfos = directoryInfo.GetFiles("*.?tf");
            foreach (FileInfo fileInfo in fileInfos)
                yield return CreateFontFamily(fileInfo.FullName);
        }
        else {
            FileInfo fileInfo = new FileInfo(location);
            if (fileInfo.Exists)
                yield return CreateFontFamily(location);
        }
    }
