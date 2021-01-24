        private static void LaunchProcess(string uri, string args)
        {
            var psi = new ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.CreateNoWindow = false;
            psi.Arguments = args;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.FileName = uri;
            var proc = Process.Start(psi);
            proc.WaitForExit();
            var exitcode =  proc.ExitCode;
        }
