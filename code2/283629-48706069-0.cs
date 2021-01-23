    var processes = Process.GetProcesses().GroupBy(g => g.ProcessName);
            List<Tuple<string, PerformanceCounter>> pcList = new List<Tuple<string, PerformanceCounter>>();
            foreach (var pg in processes)
            {
                if (pg.First().ProcessName == "Idle")
                    continue;
                if (pg.Count() == 1)
                {
                    var process_cpu = new PerformanceCounter(
                               "Process",
                               "% Processor Time",
                               pg.First().ProcessName
                                    );
                    process_cpu.NextValue();
                    pcList.Add(new Tuple<string, PerformanceCounter>(pg.First().ProcessName, process_cpu));
                }
                else
                {
                    int id = 1;
                    foreach(var p in pg)
                    {
                        var process_cpu = new PerformanceCounter(
                               "Process",
                               "% Processor Time",
                               p.ProcessName + "#" + id
                                    );
                        process_cpu.NextValue();
                        pcList.Add(new Tuple<string, PerformanceCounter>(p.ProcessName + "#" + id, process_cpu));
                        id++;
                    }
                }
            }
