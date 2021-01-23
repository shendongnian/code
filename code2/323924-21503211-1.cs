    string ExecutePSExec(string command)
    {
        string result = "";
        try
        {
            string location = AppDomain.CurrentDomain.BaseDirectory;
    
            // append output to file at the end of this string:
            string cmdWithFileOutput = string.Format("{0} >{1}temp.log 2>&1", command,location );
                    
    
            // The flag /c tells "cmd" to execute what follows and exit
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + cmdWithFileOutput);
                    
            procStartInfo.UseShellExecute = true;       // have to set shell execute to true to 
            procStartInfo.CreateNoWindow = true;
            procStartInfo.WindowStyle = ProcessWindowStyle.Hidden;      // as a window will be created set the window style to be hiddem
    
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            proc.WaitForExit();
    
    
            // now read file back.
            string filePath = string.Format("{0}temp.log", location);
            result = System.IO.File.ReadAllText(filePath);
        }
        catch (Exception objException)
        {
            // Log the exception
        }
    
        return result;
    }
