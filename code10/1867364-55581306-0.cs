    public static class DirectoryTreeDrawer
    {
        public static void DrawTree(string directoryPath, TextWriter textWriter)
        {
            DrawTree(new DirectoryInfo(directoryPath), textWriter);
        }
        public static void DrawTree(DirectoryInfo directoryInfo, TextWriter textWriter)
        {
            PrintDirectory(directoryInfo, textWriter);
        }
        private static void PrintDirectory(DirectoryInfo directory, TextWriter textWriter, 
            string prefix = "  ", string searchPattern = "*", SearchOption searchOption = 
            SearchOption.TopDirectoryOnly, bool isLast = true, bool isNested = false)
        {
            PrintItem(directory.Name, prefix, isLast, textWriter, true);
            var subDirs = directory.GetDirectories(searchPattern, searchOption);
            var files = directory.GetFiles(searchPattern, searchOption);
            // If this is a "nested" directory, add the parent's connector to the prefix
            prefix += isNested ? "│ " : "  ";
            for (var directoryIndex = 0; directoryIndex < subDirs.Length; directoryIndex++)
            {
                var isLastChild = directoryIndex == subDirs.Length - 1 && files.Length == 0;
                // If the parent has files or other directories, mark this as "nested"
                var isNestedDir = files.Length > 0 || !isLastChild;
                PrintDirectory(subDirs[directoryIndex], textWriter, prefix, searchPattern, 
                    searchOption, isLastChild, isNestedDir);
            }            
            for (var fileIndex = 0; fileIndex < files.Length; fileIndex++)
            {
                var isLastFile = fileIndex == files.Length - 1;
                PrintItem(files[fileIndex].Name, prefix, isLastFile, textWriter);
            }
        }
        private static void PrintItem(string name, string prefix, bool isLastItem, 
            TextWriter textWriter, bool isDirectory = false)
        {
            var itemConnector = isLastItem ? "└─" : "├─";
            var suffix = isDirectory ? Path.DirectorySeparatorChar.ToString() : "";
            textWriter?.WriteLine($"{prefix}{itemConnector}{name}{suffix}");
        }
    }
