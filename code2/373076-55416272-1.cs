        /// <summary>
        /// Check if a directory is the base of another
        /// </summary>
        /// <param name="root">Candidate root</param>
        /// <param name="child">Child folder</param>
        public static bool IsBaseOf(this DirectoryInfo root, DirectoryInfo child)
        {
            var directoryPath = EndsWithSeparator(new Uri(child.FullName).AbsolutePath);
            var rootPath = EndsWithSeparator(new Uri(root.FullName).AbsolutePath);
            return directoryPath.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase);
        }
        private static string EndsWithSeparator(string absolutePath)
        {
            return absolutePath?.TrimEnd('/','\\') + "/";
        }
