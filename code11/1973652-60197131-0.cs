    public static class SafeWalk {
        [Flags]
        public enum ReturnOptions {
            ReturnFiles = 1, ReturnDirectories = 2, ReturnBoth = 3
        }
    
        const string AllFiles = "*.*";
    
        // File and Directory Name Tree Walkers
    
        public static IEnumerable<string> SafeEnumerateFileAndDirNames(this DirectoryInfo di, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            di.FullName.SafeEnumerateFileAndDirNames(AllFiles, AllFiles, searchOpt, ReturnOptions.ReturnBoth);
    
        public static IEnumerable<string> SafeEnumerateFileAndDirNames(this DirectoryInfo di, string filePattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            di.FullName.SafeEnumerateFileAndDirNames(filePattern, AllFiles, searchOpt, ReturnOptions.ReturnBoth);
    
        public static IEnumerable<string> SafeEnumerateFileAndDirNames(this DirectoryInfo di, string filePattern, string dirPattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            di.FullName.SafeEnumerateFileAndDirNames(filePattern, dirPattern, searchOpt, ReturnOptions.ReturnBoth);
    
        public static IEnumerable<string> SafeEnumerateFileAndDirNames(this string path, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            path.SafeEnumerateFileAndDirNames(AllFiles, AllFiles, searchOpt, ReturnOptions.ReturnBoth);
    
        public static IEnumerable<string> SafeEnumerateFileAndDirNames(this string path, string filePattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            path.SafeEnumerateFileAndDirNames(filePattern, AllFiles, searchOpt, ReturnOptions.ReturnBoth);
    
        public static IEnumerable<string> SafeEnumerateFileAndDirNames(this string path, string filePattern, string dirPattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly, ReturnOptions returnOpt = ReturnOptions.ReturnBoth) {
            var searchQueue = new Queue<string>() { path };
    
            while (searchQueue.Count > 0) {
                var cdn = searchQueue.Dequeue();
    
                IEnumerable<string> cdiFiles = null;
                if (returnOpt.HasFlag(ReturnOptions.ReturnFiles)) {
                    try {
                        cdiFiles = Directory.EnumerateFiles(cdn, filePattern, SearchOption.TopDirectoryOnly);
                    }
                    catch (Exception) {
                    }
    
                    if (cdiFiles != null)
                        foreach (var filename in cdiFiles)
                            yield return filename;
                }
    
                if ((!returnOpt.HasFlag(ReturnOptions.ReturnFiles) || cdiFiles != null) && (returnOpt.HasFlag(ReturnOptions.ReturnDirectories) || searchOpt == SearchOption.AllDirectories)) { // skip if file enumeration failed
                    IEnumerable<string> cdiDirs = null;
                    try {
                        cdiDirs = Directory.EnumerateDirectories(cdn, dirPattern, SearchOption.TopDirectoryOnly);
                    }
                    catch (Exception) {
                    }
    
                    if (cdiDirs != null) {
                        foreach (var dirname in cdiDirs) {
                            if (searchOpt == SearchOption.AllDirectories)
                                searchQueue.Enqueue(dirname);
    
                            if (returnOpt.HasFlag(ReturnOptions.ReturnDirectories))
                                yield return dirname;
                        }
                    }
                }
            }
        }
    
        public static IEnumerable<string> SafeEnumerateFileNames(this string path, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            path.SafeEnumerateFileAndDirNames(AllFiles, AllFiles, searchOpt, ReturnOptions.ReturnFiles);
    
        public static IEnumerable<string> SafeEnumerateFileNames(this string path, string filePattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            path.SafeEnumerateFileAndDirNames(filePattern, AllFiles, searchOpt, ReturnOptions.ReturnFiles);
    
        public static IEnumerable<string> SafeEnumerateFileNames(this string path, string filePattern, string dirPattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            path.SafeEnumerateFileAndDirNames(filePattern, dirPattern, searchOpt, ReturnOptions.ReturnFiles);
    
        public static IEnumerable<string> SafeEnumerateFileNames(this DirectoryInfo path, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            path.FullName.SafeEnumerateFileAndDirNames(AllFiles, AllFiles, searchOpt, ReturnOptions.ReturnFiles);
    
        public static IEnumerable<string> SafeEnumerateFileNames(this DirectoryInfo path, string filePattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            path.FullName.SafeEnumerateFileAndDirNames(filePattern, AllFiles, searchOpt, ReturnOptions.ReturnFiles);
    
        public static IEnumerable<string> SafeEnumerateFileNames(this DirectoryInfo path, string filePattern, string dirPattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            path.FullName.SafeEnumerateFileAndDirNames(filePattern, dirPattern, searchOpt, ReturnOptions.ReturnFiles);
    
        public static IEnumerable<string> SafeEnumerateDirectoryNames(this string path, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            path.SafeEnumerateFileAndDirNames(AllFiles, AllFiles, searchOpt, ReturnOptions.ReturnDirectories);
    
        public static IEnumerable<string> SafeEnumerateDirectoryNames(this string path, string dirPattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            path.SafeEnumerateFileAndDirNames(AllFiles, dirPattern, searchOpt, ReturnOptions.ReturnDirectories);
    
        public static IEnumerable<string> SafeEnumerateDirectoryNames(this DirectoryInfo path, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            path.FullName.SafeEnumerateFileAndDirNames(AllFiles, AllFiles, searchOpt, ReturnOptions.ReturnDirectories);
    
        public static IEnumerable<string> SafeEnumerateDirectoryNames(this DirectoryInfo path, string dirPattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            path.FullName.SafeEnumerateFileAndDirNames(AllFiles, dirPattern, searchOpt, ReturnOptions.ReturnDirectories);
    
        // File and Directory Info Tree Walkers
    
        public static IEnumerable<FileSystemInfo> SafeEnumerateFileSystemInfos(this string path, SearchOption searchOpt = SearchOption.TopDirectoryOnly, ReturnOptions returnOpt = ReturnOptions.ReturnBoth) =>
            new DirectoryInfo(path).SafeEnumerateFileSystemInfos(AllFiles, AllFiles, searchOpt, returnOpt);
    
        public static IEnumerable<FileSystemInfo> SafeEnumerateFileSystemInfos(this string path, string searchPattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly, ReturnOptions returnOpt = ReturnOptions.ReturnBoth) =>
            new DirectoryInfo(path).SafeEnumerateFileSystemInfos(searchPattern, searchPattern, searchOpt, returnOpt);
    
        public static IEnumerable<FileSystemInfo> SafeEnumerateFileSystemInfos(this string path, string filePattern, string dirPattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly, ReturnOptions returnOpt = ReturnOptions.ReturnBoth) =>
            new DirectoryInfo(path).SafeEnumerateFileSystemInfos(filePattern, dirPattern, searchOpt, returnOpt);
    
        public static IEnumerable<FileSystemInfo> SafeEnumerateFileSystemInfos(this DirectoryInfo di, SearchOption searchOpt = SearchOption.TopDirectoryOnly, ReturnOptions returnOpt = ReturnOptions.ReturnBoth) =>
            di.SafeEnumerateFileSystemInfos(AllFiles, AllFiles, searchOpt, returnOpt);
    
        public static IEnumerable<FileSystemInfo> SafeEnumerateFileSystemInfos(this DirectoryInfo di, string searchPattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly, ReturnOptions returnOpt = ReturnOptions.ReturnBoth) =>
            di.SafeEnumerateFileSystemInfos(searchPattern, searchPattern, searchOpt, returnOpt);
    
        public static IEnumerable<FileSystemInfo> SafeEnumerateFileSystemInfos(this DirectoryInfo di, string filePattern, string dirPattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly, ReturnOptions returnOpt = ReturnOptions.ReturnBoth) {
            var searchQueue = new Queue<DirectoryInfo>();
            searchQueue.Enqueue(di);
            while (searchQueue.Count > 0) {
                var cdi = searchQueue.Dequeue();
    
                IEnumerable<string> cdiFiles = null;
                if (returnOpt.HasFlag(ReturnOptions.ReturnFiles)) {
                    try {
                        cdiFiles = Directory.EnumerateFiles(cdi.FullName, filePattern, SearchOption.TopDirectoryOnly);
                    }
                    catch (Exception) {
                    }
    
                    if (cdiFiles != null) {
                        var cfis = new ConcurrentBag<FileInfo>();
                        cdiFiles.AsParallel()
                                .ForAll(f => {
                                    try {
                                        cfis.Add(new FileInfo(f));
                                    }
                                    catch (Exception) {
                                    }
                                });
    
                        foreach (var fi in cfis)
                            yield return fi;
                    }
                }
    
                if ((!returnOpt.HasFlag(ReturnOptions.ReturnFiles) || cdiFiles != null) && (returnOpt.HasFlag(ReturnOptions.ReturnDirectories) || searchOpt.HasFlag(SearchOption.AllDirectories))) { // skip if file enumeration failed
                    IEnumerable<string> cdiDirs = null;
                    try {
                        cdiDirs = Directory.EnumerateDirectories(cdi.FullName, dirPattern, SearchOption.TopDirectoryOnly);
                    }
                    catch (Exception) {
                    }
    
                    if (cdiDirs != null) {
                        var cdis = new ConcurrentBag<DirectoryInfo>();
                        cdiDirs.AsParallel()
                               .ForAll(d => {
                                   try {
                                       cdis.Add(new DirectoryInfo(d));
                                   }
                                   catch (Exception) {
                                   }
                               });
                        foreach (var rdi in cdis) {
                            if (returnOpt.HasFlag(ReturnOptions.ReturnDirectories))
                                yield return rdi;
                            if (searchOpt == SearchOption.AllDirectories)
                                searchQueue.Enqueue(rdi);
                        }
                    }
                }
            }
        }
    
        public static IEnumerable<FileInfo> SafeEnumerateFileInfos(this string path, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            new DirectoryInfo(path).SafeEnumerateFileSystemInfos(AllFiles, AllFiles, searchOpt, ReturnOptions.ReturnFiles).Cast<FileInfo>();
    
        public static IEnumerable<FileInfo> SafeEnumerateFileInfos(this string path, string filePattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            new DirectoryInfo(path).SafeEnumerateFileSystemInfos(filePattern, AllFiles, searchOpt, ReturnOptions.ReturnFiles).Cast<FileInfo>();
    
        public static IEnumerable<FileInfo> SafeEnumerateFileInfos(this string path, string filePattern, string dirPattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            new DirectoryInfo(path).SafeEnumerateFileSystemInfos(filePattern, dirPattern, searchOpt, ReturnOptions.ReturnFiles).Cast<FileInfo>();
    
        public static IEnumerable<FileInfo> SafeEnumerateFileInfos(this DirectoryInfo di, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            di.SafeEnumerateFileSystemInfos(AllFiles, AllFiles, searchOpt, ReturnOptions.ReturnFiles).Cast<FileInfo>();
    
        public static IEnumerable<FileInfo> SafeEnumerateFileInfos(this DirectoryInfo di, string filePattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            di.SafeEnumerateFileSystemInfos(filePattern, AllFiles, searchOpt, ReturnOptions.ReturnFiles).Cast<FileInfo>();
    
        public static IEnumerable<FileInfo> SafeEnumerateFileInfos(this DirectoryInfo di, string filePattern, string dirPattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            di.SafeEnumerateFileSystemInfos(filePattern, dirPattern, searchOpt, ReturnOptions.ReturnFiles).Cast<FileInfo>();
    
        public static IEnumerable<DirectoryInfo> SafeEnumerateDirectoryInfos(this string path, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            new DirectoryInfo(path).SafeEnumerateFileSystemInfos(AllFiles, AllFiles, searchOpt, ReturnOptions.ReturnDirectories).Cast<DirectoryInfo>();
    
        public static IEnumerable<DirectoryInfo> SafeEnumerateDirectoryInfos(this string path, string dirPattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            new DirectoryInfo(path).SafeEnumerateFileSystemInfos(AllFiles, dirPattern, searchOpt, ReturnOptions.ReturnDirectories).Cast<DirectoryInfo>();
    
        public static IEnumerable<DirectoryInfo> SafeEnumerateDirectoryInfos(this DirectoryInfo di, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            di.SafeEnumerateFileSystemInfos(AllFiles, AllFiles, searchOpt, ReturnOptions.ReturnDirectories).Cast<DirectoryInfo>();
    
        public static IEnumerable<DirectoryInfo> SafeEnumerateDirectoryInfos(this DirectoryInfo di, string dirPattern, SearchOption searchOpt = SearchOption.TopDirectoryOnly) =>
            di.SafeEnumerateFileSystemInfos(AllFiles, dirPattern, searchOpt, ReturnOptions.ReturnDirectories).Cast<DirectoryInfo>();
    }
