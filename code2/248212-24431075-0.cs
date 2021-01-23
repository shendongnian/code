    private void UninstallExistingService()
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo();
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;
            process.Start();
            using (var sw = process.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("{0} {1}", "net stop", _serviceName);
                    sw.WriteLine("{0} {1}", "sc delete", _serviceName);
                }
            }
            process.WaitForExit();
        }
