        static void StartAzureStorageEmulator()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = Path.Combine(SDKDirectory, "csrun.exe"),
                Arguments = "/devstore",
            };
            using (Process process = Process.Start(processStartInfo))
            {
                process.WaitForExit();
            }
        }
