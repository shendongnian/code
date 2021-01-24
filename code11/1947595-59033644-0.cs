           public static async Task Main(string[] args)
           {
            string pathToContentRoot = string.Empty;
           
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                pathToContentRoot = Path.GetDirectoryName(pathToExe);
                Directory.SetCurrentDirectory(pathToContentRoot);
