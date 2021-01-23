            Process[] runningProcesses = Process.GetProcesses();
            var currentSessionID = Process.GetCurrentProcess().SessionId;
            Process[] sameAsthisSession = (from c in runningProcesses where c.SessionId == currentSessionID select c).ToArray();
            foreach (var p in sameAsthisSession)
            {
               Trace.WriteLine(p.ProcessName); 
            }
