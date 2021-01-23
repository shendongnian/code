    int currentProcessId = Process.GetCurrentProcess().Id;
    foreach (var process in Process.GetProcesses()) {
                  if (process.Id != currentProcessId)
                  {
                    var files = GetFilesLockedBy(process);
                    if (files.Contains(filePath))
                    {
                        procs.Add(process);
                        Console.WriteLine(process.ProcessName);
                        process.Kill();
                    }
                  }
                }
    File.Delete(filePath);
