            ProcessStartInfo si = new ProcessStartInfo();
            si.FileName = "praat.exe";     //name of the handle program from sysinternals
                                            //assumes that its in the exe directory or in your path 
                                            //environment variable
            //the following three lines are required to be able to read the output (StandardOutput)
            //and hide the exe window.
            si.RedirectStandardOutput = true;
            si.WindowStyle = ProcessWindowStyle.Hidden;
            si.UseShellExecute = false;
            si.Arguments = "InputArgsHere";     //You can specify whatever parameters praat.exe needs here
            //these 4 lines create a process object, start it, then read the output to 
            //a new string variable "s"
            Process p = new Process();
            p.StartInfo = si;
            p.Start();
            string s = p.StandardOutput.ReadToEnd();
