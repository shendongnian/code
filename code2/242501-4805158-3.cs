    public static class myExtensions
    {
        public static IEnumerable<string> GetFileNamesWithoutExtensions(this DirectoryInfo di)
        {
            return di.GetFiles()
                .Select(x => Path.GetFileNameWithoutExtension(x.FullName));
        }
    }
