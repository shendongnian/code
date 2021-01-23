    public static string GenerateFileName(string extension="")
    {
        return string.Concat(Path.GetRandomFileName().Replace(".", ""),
            (!string.IsNullOrEmpty(extension)) ? (extension.StartsWith(".") ? extension : string.Concat(".", extension)) : "");
    }
