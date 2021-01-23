    using System.Diagnostic;
    ...
    void StopAllPackages() {
        // Get all processes executing an SSIS package on the database server.
        // If you run this on the database server itself, remove the second parameter
        // from GetProcessesByName.
        foreach(Process p in Process.GetProcessesByName("dtexec.exe","databaseServerMachine") {
            try { p.Kill(); }
            catch(Win32Exception w32e) {
                // process was already terminating or can't be terminated
            }
            catch(InvalidOperationException ioe) {
                // process has already exited
            }
        }
    }
