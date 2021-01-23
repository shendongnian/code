    foreach (var proc in Process.GetProcesses())
            {
                if (proc.Id == Process.GetCurrentProcess().Id) continue;
                var currName = AssemblyName.GetAssemblyName(Process.GetCurrentProcess().MainModule.FileName);
                var procName = AssemblyName.GetAssemblyName(proc.MainModule.FileName);
                if (currName.FullName == procName.FullName && /*and other parameters*/)
                    return;
            }
