    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
       class Program
       {
          static void Main(string[] args)
          {
             Process[] procs = Process.GetProcesses();
             foreach (Process proc in procs)
             {
                string processName = proc.ProcessName;
                int processId = proc.Id;
    
                try
                {
                   if(ProcessExtensions.HasDesktop40CLR(proc))
                      Console.WriteLine("#{0}, {1} (has Desktop CLR 4.0+)", processId, processName);
    
                   if(ProcessExtensions.HasOlderDesktopCLR(proc))
                      Console.WriteLine("#{0}, {1} (has Older Desktop CLR)", processId, processName);
    
                   if (ProcessExtensions.HasMscorlib(proc))
                      Console.WriteLine("#{0}, {1} (has MSCORLib)", processId, processName);
                }
                catch (Exception)
                {
                   Console.WriteLine("#{0}, {1} (skipped/unknown)", processId, processName);
                }
             }
          }
       }
    
       public static class ProcessExtensions
       {
          public static bool HasDesktop40CLR(Process proc)
          {
             for (int ix = 0; ix < proc.Modules.Count; ++ix)
             {
                var moduleName = proc.Modules[ix].ModuleName;
    
                if (string.Compare(moduleName, "mscoree.dll", ignoreCase: true) == 0)
                   return true;
             }
    
             return false;
          }
    
          public static bool HasOlderDesktopCLR(Process proc)
          {
             for (int ix = 0; ix < proc.Modules.Count; ++ix)
             {
                var moduleName = proc.Modules[ix].ModuleName;
    
                if (string.Compare(moduleName, "mscorwks.dll", ignoreCase: true) == 0)
                   return true;
             }
    
             return false;
          }
    
          public static bool HasMscorlib(Process proc)
          {
             for (int ix = 0; ix < proc.Modules.Count; ++ix)
             {
                var moduleName = proc.Modules[ix].ModuleName;
    
                if (string.Compare(moduleName, "mscorlib.dll", ignoreCase: true) == 0)
                   return true;
    
                if (string.Compare(moduleName, "mscorlib.ni.dll", ignoreCase: true) == 0)
                   return true;
             }
    
             return false;
          }
       }
    }
