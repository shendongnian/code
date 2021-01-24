    class Program
    {
        static async Task Main()
        {
            await ConfigureLogger();
            int procId = GetWebSiteProcessId();
            Process WebSiteProc = null;
            try
            {
                if (procId != -1) WebSiteProc = Process.GetProcessById(procId);
            }
            catch (ArgumentException err) when (err.Message.IndexOf($"{procId} is not running") > -1)
            {
                DeleteFileProcessId();
            }
            if (WebSiteProc != null)
            {
                Log.Information($"ID: {procId}");
                Log.Information("WebSite is working");
                Log.CloseAndFlush();
            }
            else
            {
                Log.Information("Restarting the WebSite");
                var command = $@"cd {Pathes.pathToWorkDirectory}; ";
                command += @"dotnet ./WebSite/WebSite.dll; ";
                Log.CloseAndFlush();
                await ExecuteCommand(command);
            }
        }
        private static async Task ExecuteCommand(string command)
        {
            using (Process proc = new Process())
            {
                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c \" " + command + " \"";
                proc.StartInfo.UseShellExecute = false;
                proc.Start();
                var procId = proc.Id.ToString();
                await WriteProcessIdToFile(procId);
            }
        }
        private static async Task ConfigureLogger()
        {
            var logConfig = new LoggerConfiguration()
                   .MinimumLevel.Debug()
                   .WriteTo.Console()
                   .WriteTo.Seq(ConfigJson.Seq);
            Log.Logger = logConfig.CreateLogger();
        }
        private static async Task WriteProcessIdToFile(string id)
        {
            var fm = new ClassLibrary.File_Manager();
            var path = Path.Combine(Pathes.pathToWorkDirectory, "WebSiteProcessId.txt");
            fm.OpenFile(path, "Write", id);
        }
        private static int GetWebSiteProcessId()
        {
            var directoryFiles = new DirectoryInfo(Pathes.pathToWorkDirectory).GetFiles();
            var file = directoryFiles
            .Where(file => file.Name == "WebSiteProcessId.txt")
            .SingleOrDefault();
            if (file == null) return -1;
            var fm = new ClassLibrary.File_Manager();
            var path = Path.Combine(Pathes.pathToWorkDirectory, "WebSiteProcessId.txt");
            string idStr = fm.OpenFile(path, "Read", null).fileData;
            int id = Convert.ToInt32(idStr);
            return id;
        }
        private static void DeleteFileProcessId()
        {
            var directoryFiles = new DirectoryInfo(Pathes.pathToWorkDirectory).GetFiles();
            var file = directoryFiles
            .Where(file => file.Name == "WebSiteProcessId.txt")
            .SingleOrDefault();
            if (file != null)
            {
                File.Delete(file.FullName);
            }
        }
    }
