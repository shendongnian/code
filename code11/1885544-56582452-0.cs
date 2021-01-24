            using (ServerManager s = new ServerManager())
            {
                var processList = from m in Process.GetProcessesByName("w3wp") select m.Id;
                IEnumerable<WorkerProcess> workerP = (from p in s.ApplicationPools
                                                      from w in p.WorkerProcesses
                                                      where processList.Any(vn => vn == w.ProcessId)
                                                      select w);
                foreach (var workProcess in workerP)
                {
                    Console.WriteLine(
                        $"{workProcess.AppPoolName} Id:{workProcess.ProcessId} AppDomains Count: {workProcess.ApplicationDomains?.Count}");
                    var ad = workProcess.ApplicationDomains;
                    if (!ad.Any()) continue;
                    foreach (var curDomain in ad)
                    {
                        Console.WriteLine($"AppDomain: {curDomain.Id} {curDomain.VirtualPath}");
                    }
                }
            }
