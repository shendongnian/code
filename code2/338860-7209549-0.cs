    private int ExecuteCommand(string arguments, string passPhrase, int timeout)
            {
                Process processObject;
                ProcessStartInfo pInfo = new ProcessStartInfo(_executablePath, arguments);
    
               
                pInfo.CreateNoWindow = true;
                pInfo.UseShellExecute = false;
    
                pInfo.RedirectStandardInput = true;
                pInfo.RedirectStandardOutput = true;
                pInfo.RedirectStandardError = true;
                processObject = Process.Start(pInfo);
    
                if (!string.IsNullOrEmpty(passPhrase))
                {
                    processObject.StandardInput.WriteLine(passPhrase);
                    processObject.StandardInput.Flush();
                }
    
                string result = processObject.StandardOutput.ReadToEnd();
                string error = processObject.StandardError.ReadToEnd();
    
                if (!processObject.WaitForExit(timeout))
                {
                    throw new TimeoutException("GnuPG operation timeout. Waited " + timeout + " milliseconds ");
                }
    
                int exitcode = processObject.ExitCode;
    
                Error = error;
                Output = result;
    
                return exitcode;
                
            }
