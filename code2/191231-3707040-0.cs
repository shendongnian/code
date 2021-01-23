    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace Stackoverflow_Test
    {
        public class PlinkWrapper
        {
            private string host { get; set; }
            /// <summary>
            /// Initializes the <see cref="PlinkWrapper"/>
            /// Assumes the key for the user is already loaded in PageAnt.
            /// </summary>
            /// <param name="host">The host, on format user@host</param>
            public PlinkWrapper(string host)
            {
                this.host = host;
            }
    
            /// <summary>
            /// Runs a command and returns the output lines in a List&lt;string&gt;.
            /// </summary>
            /// <param name="command">The command to execute</param>
            /// <returns></returns>
            public List<string> RunCommand(string command)
            {
                List<string> result = new List<string>();
    
                ProcessStartInfo startInfo = new ProcessStartInfo("plink.exe");
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.CreateNoWindow = true;
                startInfo.Arguments = host + " " + command;
                using (Process p = new Process())
                {
                    p.StartInfo = startInfo;
                    p.Start();
                    while (p.StandardOutput.Peek() >= 0)
                    {
                        result.Add(p.StandardOutput.ReadLine());
                    }
                    p.WaitForExit();
                }
    
                return result;
            }
        }
    }
