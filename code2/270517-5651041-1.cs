     private bool IsProcessRunning()
        {
            int pcReturn = -1;
            bool blRunning = false;
            String strCmd = @"cscript";
            String arg = "//B //Nologo ProcessSearch.vbs YourProcess.exe";
            System.Diagnostics.ProcessStartInfo psi = new     System.Diagnostics.ProcessStartInfo(strCmd);
            psi.RedirectStandardOutput = true;
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            psi.Arguments = arg;
            System.Diagnostics.Process procQuery;
            procQuery = System.Diagnostics.Process.Start(psi);
            String output = procQuery.StandardOutput.ReadToEnd();
            procQuery.WaitForExit();
            if (procQuery.HasExited)
            {
                bool isInt = Int32.TryParse(output, out pcReturn);
                if (!isInt)
                {
                    pcReturn = -1;
                }
                else
                {
                    if (pcReturn > 1)
                    {
                        blRunning = true;
                    }
                }
            }
            return blRunning;
        }
