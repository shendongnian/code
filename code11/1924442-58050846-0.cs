        using System.Diagnostics;
        private static void StartProcess(string exeName,string parameter)
        {
            Process process = new Process();
            process.StartInfo.FileName = exeName; 
            process.StartInfo.Arguments = parameter;
            process.EnableRaisingEvents = true;
            process.Start();
        }
