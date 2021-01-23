                ProcessStartInfo info = new ProcessStartInfo("programName_installer.exe", @"\qn");
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                info.UseShellExecute = false;
                info.RedirectStandardError = 
                    info.RedirectStandardOutput = true;
    
                using (Process process = Process.Start(info))
                {
                    process.WaitForExit();
    
                    string output = process.StandardOutput.ReadToEnd();
    
                    string error = process.StandardError.ReadToEnd();
    
                    int exitCode = process.ExitCode;
                }
