    public static int RunAsAdmin(string fileName)
    {
            ProcessStartInfo psi = new ProcessStartInfo(fileName);
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = true;
            psi.Verb = "runas";
            psi.Arguments = modifiers;
 
            try
            {
                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                    if (process.HasExited)
                        return process.ExitCode;
                }
            }
            catch (Win32Exception wex)
            {
            }
        
        return 0;
    }
