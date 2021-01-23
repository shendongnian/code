    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace CheckHD
    {
            class HDSerial
            {
                const string MY_SERIAL = "F845-BB23";
                public static bool CheckSerial()
                {
                    string res = ExecuteCommandSync("vol");
                    const string search = "Number is";
                    int startI = res.IndexOf(search, StringComparison.InvariantCultureIgnoreCase);
        
                    if (startI > 0)
                    {
                        string currentDiskID = res.Substring(startI + search.Length).Trim();
                        if (currentDiskID.Equals(MY_SERIAL))
                            return true;
                    }
                    return false;
                }
        
                public static string ExecuteCommandSync(object command)
                {
                    try
                    {
                        // create the ProcessStartInfo using "cmd" as the program to be run,
                        // and "/c " as the parameters.
                        // Incidentally, /c tells cmd that we want it to execute the command that follows,
                        // and then exit.
                        System.Diagnostics.ProcessStartInfo procStartInfo =
                            new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
        
                        // The following commands are needed to redirect the standard output.
                        // This means that it will be redirected to the Process.StandardOutput StreamReader.
                        procStartInfo.RedirectStandardOutput = true;
                        procStartInfo.UseShellExecute = false;
                        // Do not create the black window.
                        procStartInfo.CreateNoWindow = true;
                        // Now we create a process, assign its ProcessStartInfo and start it
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.StartInfo = procStartInfo;
                        proc.Start();
                        // Get the output into a string
                        string result = proc.StandardOutput.ReadToEnd();
                        // Display the command output.
                        return result;
                    }
                    catch (Exception)
                    {
                        // Log the exception
                        return null;
                    }
                }
            }
        }
