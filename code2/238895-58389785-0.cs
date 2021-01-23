    public static class Ext
    {
       private static string AssemblyFileName(this Assembly myAssembly)
        {
            string strLoc = myAssembly.Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string sExeName = fileInfo.Name;
            return sExeName;
        }
        private static int HowManyTimesIsProcessRunning(string name)
        {
            int count = 0;
            name = name.ToLowerInvariant().Trim().Replace(".exe", "");
            foreach (Process clsProcess in Process.GetProcesses())
            {
                var processName = clsProcess.ProcessName.ToLowerInvariant().Trim();
                // System.Diagnostics.Debug.WriteLine(processName);
                if (processName.Contains(name))
                {
                    count++;
                };
            };
            return count;
        }
        public static int HowManyTimesIsAssemblyRunning(this Assembly myAssembly)
        {
            var fileName = AssemblyFileName(myAssembly);
            return HowManyTimesIsProcessRunning(fileName);
        }
    }
