    static void Main(string[] args)
        {
            var path = "c:/test"; //Create the directory with some files
            var latestFile = "c:/test/test2.txt"; // Name of one file which is in c:/test
            var targetPath = "c:/test2"; //Create the directory
            Directory.GetFiles(path)
                .Where(e => File.GetLastWriteTime(e).Date.Equals(File.GetLastWriteTime(latestFile).Date))
                .ToList()
                .ForEach(e =>
                {
                    Console.WriteLine($"Copying {e}");
                    File.Copy(e, Path.Join(targetPath, Path.GetFileName(e)), true);
                });
        }
