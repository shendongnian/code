        public enum ProcessResult
            {
                ProcessAlreadyRunning,
                FailedToLaunch,
                SuccessfulLaunch
            }
        public static async Task<ProcessResult> CheckLaunchCheckProcess1()
            {
                if (await CheckForRunningProcess("ProcessName1.exe")) return ProcessResult.ProcessAlreadyRunning;
                LaunchProcess(1);
                return await CheckForRunningProcess("ProcessName1.exe") ? ProcessResult.SuccessfulLaunch : ProcessResult.FailedToLaunch;
            }
