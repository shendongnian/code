    public static class PathUtils
    {
        public static string RealPath(string inputPath)
        {
            return Directory.GetFiles(Path.GetDirectoryName(inputPath))
                .FirstOrDefault(p => String.Equals(Path.GetFileName(p), 
                    Path.GetFileName(inputPath), StringComparison.OrdinalIgnoreCase));
        }
    }
