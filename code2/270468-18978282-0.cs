    using System.Diagnostics;
    ProcessModuleCollection modules = Process.GetCurrentProcess().Modules;
    string processpathfilename;
    string processmodulename;
    if (modules.Count > 0) {
        processpathfilename = modules[0].FileName;
        processmodulename= modules[0].ModuleName;
    } else {
        throw new ExecutionEngineException("Something critical occurred with the running process.");
    }
