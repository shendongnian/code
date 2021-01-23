        /// <summary>
        /// Check if a directory is a descendant of another
        /// </summary>
        /// <param name="child">Child folder</param>
        /// <param name="root">Candidate root</param>
        public static bool IsBaseOf(this DirectoryInfo child, DirectoryInfo root)
        {
            var directoryPath = EndsWithSeparator(new Uri(child.FullName).AbsolutePath);
            var rootPath = EndsWithSeparator(new Uri(root.FullName).AbsolutePath);
            return directoryPath.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase);
        }
        private static string EndsWithSeparator(string absolutePath)
        {
            return absolutePath?.TrimEnd('/','\\') + "/";
        }
