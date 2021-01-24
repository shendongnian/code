    public static Process runProcRasdial(string VPNName, string username, SecureString password)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd")
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = false,
                UseShellExecute = false
            };
            var proc = new Process()
            {
                StartInfo = psi,
                EnableRaisingEvents = true,
            };
            proc.Start();
            proc.StandardInput.WriteLine("rasdial {0} {1} {2}", VPNName, username, password);
            proc.StandardInput.WriteLine("exit");
            proc.WaitForExit();
            return proc;
        }
