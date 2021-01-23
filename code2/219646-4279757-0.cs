    public static int StartViewer(string file)
        {
            string parameters = string.Format("-R -M {0}", file);
            ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            psi.FileName = "C:\Program Files\Vim\vim72\gvim.exe";
            psi.Arguments = parameters;
            Process p = Process.Start(psi);
            p.WaitForExit();
            return p.ExitCode;
        }
