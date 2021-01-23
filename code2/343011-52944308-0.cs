    public static int Start(string processName)
        {
            var process =
                Process.Start(processName);
            return
                process.Id;
        }
        public static void Stop(int processId)
        {
            var process =
                Process.GetProcessById(processId);
            process.Kill();
        }
