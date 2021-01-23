               using (Process proc = new Process())
                {
    
                    proc.StartInfo.FileName = filename;
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.WorkingDirectory = ClientInstallPath;
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    
                    proc.Start();
    
                    if (proc != null)
                    {
                        proc.WaitForExit();
                        returnCode = proc.ExitCode;
                    }
                }
