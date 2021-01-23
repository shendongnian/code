    using System.Diagnostics;
     var processStartInfo = new ProcessStartInfo
                                       {
                                           Arguments = "ping google.com",
                                           FileName = "cmd"
                                       };
           
            Process process = Process.Start(processStartInfo);
