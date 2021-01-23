    var processss = from proc in System.Diagnostics.Process.GetProcesses() 
                     orderby proc.ProcessName ascending
                      select proc;
            foreach (var item in processss)
            {
                Console.WriteLine(item.ProcessName );
                
            }
