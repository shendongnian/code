            List<Process> processes = Process.GetProcesses().ToList();
            List<Process> safeProcesses  = processes .Select(X => 
            {
                try {  ProcessModule  pp = X.MainModule; return X; }
                catch { return null; }
            }).Where(X=>X!=null).ToList();
