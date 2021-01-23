                try
                {
                     bool pathExists = File.Exists(module.ExecutionPath);
                     if (pathExists)
                     {
                         ProcessStartInfo startArgs = new ProcessStartInfo();
                         startArgs.FileName = "C:\Windows\System32\notepad.exe";
                         startArgs.Arguments = null;
                
                         Process process = new Process();
                         process.StartInfo = startArgs;
                         process.Start();
                
                        Process startedProcess = CheckIfProcessStarted(process);
                     }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message + "  " + ex.InnerException);
                    Debug.WriteLine("Couldnt find the process so it never ran");
                }
            
                private Process CheckIfProcessStarted(Process process)
                {
                    return Process.GetProcessById(process.Id);
                }
