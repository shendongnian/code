    public static List<string> GetFilesCreatedAfter(string directoryName, DateTime dt)
            {
                var directory = new DirectoryInfo(directoryName);
                if (!directory.Exists)
                    throw new InvalidOperationException("Directory does not exist : " + directoryName);
                var files = new List<string>();
                files.AddRange(directory.GetFiles().Where(n => n.CreationTime > dt).Select(n=>n.FullName));
                foreach (var subDirectory in Directory.GetDirectories(directoryName))
                {
                    files.AddRange(GetFilesCreatedAfter(subDirectory,dt));
                }
                return files;
            }
