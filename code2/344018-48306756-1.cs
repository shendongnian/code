    public static class StringExtensions {
        public static bool PathEquals(this string path1, string path2) {
            return Path.GetFullPath(path1)
                .Equals(Path.GetFullPath(path2), StringComparison.InvariantCultureIgnoreCase);
        }
    }
