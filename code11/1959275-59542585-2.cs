    class Program
        {
            static List<FileInfo> GetFiles(string path, bool recursive = false)
            {
                List<FileInfo> files = new List<FileInfo>();
                DirectoryInfo di = new DirectoryInfo(path);
                files.AddRange(di.GetFiles());
                if (recursive)
                {
                    var directories = di.GetDirectories();
                    if(directories.Length > 0)
                        foreach(var dir in directories)
                            files.AddRange(GetFiles(dir.FullName, true));
                }
                return files;
            }
            static List<string> OrderByCreation(List<FileInfo> files, bool descend = false)
            {
                IOrderedEnumerable<FileInfo> orderedfiles = null;
                orderedfiles = descend
                    ? files.OrderByDescending(item => item.CreationTime)
                    : files.OrderBy(item => item.CreationTime);
                return orderedfiles.Select(item => item.FullName).ToList();
            }
            static void Main(string[] args)
            {
                var list = GetFiles(@"C:\MyDirectory", true);
                var files = OrderByCreation(list, true);
            }
        }
