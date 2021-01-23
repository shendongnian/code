    public static void ExecuteCommand(string command, string workingFolder)
            {
                int ExitCode;
                ProcessStartInfo ProcessInfo;
                Process process;
    
                ProcessInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                ProcessInfo.CreateNoWindow = true;
                ProcessInfo.UseShellExecute = false;
                ProcessInfo.WorkingDirectory = workingFolder;
                // *** Redirect the output ***
                ProcessInfo.RedirectStandardError = true;
                ProcessInfo.RedirectStandardOutput = true;
    
                process = Process.Start(ProcessInfo);
                process.WaitForExit();
    
                // *** Read the streams ***
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
    
                ExitCode = process.ExitCode;
    
                MessageBox.Show("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
                MessageBox.Show("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
                MessageBox.Show("ExitCode: " + ExitCode.ToString(), "ExecuteCommand");
                process.Close();
            }
