    public class ParallelLinq
    {
        public IList<string> SearchFolders = new List<string>
        {
            @"C:\Windows" //can be multiple
        };
        private static string[] TryGetTopDirectories(string path)
        {
            try
            {
                return Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
            }
            catch
            {
                return new string[0];
            }
        }
        private static IEnumerable<string> GetSubfolders(string path, SearchOption searchOption)
        {
            if (searchOption == SearchOption.TopDirectoryOnly)
            {
                return TryGetTopDirectories(path);
            }
            else
            {
                var topFolders = TryGetTopDirectories(path);
                return topFolders.Concat(
                    topFolders.SelectMany(subFolder => GetSubfolders(subFolder, searchOption)));
            }
        }
        protected virtual ParallelQuery<string> GetFiles(string path, string[] searchPatterns, SearchOption searchOption = SearchOption.AllDirectories)
        {
            return GetSubfolders(path, searchOption).AsParallel()
                .SelectMany(subfolder =>
                {
                    try
                    {
                        return searchPatterns.SelectMany(searchPattern => Directory.EnumerateFiles(subfolder, searchPattern)).ToArray();
                    }
                    catch (Exception ex) //catch UnauthoizedException/IOExceptions
                    {
                        return Enumerable.Empty<string>();
                    }
                });
        }
        public IEnumerable<string> Find(IList<string> patterns)
        {
            var testResultFiles = Enumerable.Empty<string>();
            if (!SearchFolders.Any() || !patterns.Any())
            {
                return testResultFiles;
            }
            testResultFiles = SearchFolders.AsParallel().Aggregate(testResultFiles, (current, folder) => current.Union(GetFiles(folder, patterns.ToArray())));
            return testResultFiles;
        }
    }
