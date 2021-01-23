        /// <summary>
        /// Returns the names of files in a specified directories that match the specified patterns using LINQ
        /// </summary>
        /// <param name="srcDirs">The directories to seach</param>
        /// <param name="searchPatterns">the list of search patterns</param>
        /// <param name="searchOption"></param>
        /// <returns>The list of files that match the specified pattern</returns>
        public static string[] GetFilesUsingLINQ(string[] srcDirs,
             string[] searchPatterns,
             SearchOption searchOption = SearchOption.AllDirectories)
        {
            var r = from dir in srcDirs
                    from searchPattern in searchPatterns
                    from f in Directory.GetFiles(dir, searchPattern, searchOption)
                    select f;
            return r.ToArray();
        }
