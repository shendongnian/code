        static async Task Main()
        {
            await ConfigureLogger();
            int procId = GetWebSiteProcessId();
            Log.Information($"ID: {procId}");
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
                Log.Information("WebSite is working");
                Log.CloseAndFlush();
            }
            else
            {
                Log.Information("Restarting the WebSite");
                var command = $@"cd {Pathes.pathToWorkDirectory}; ";
                command += @"killall dotnet ./WebSite/WebSite.dll; ";
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
