    ///--------------------------------------------------------------------------------  
    /// <summary>This method launches the diagnostics to review the solution.</summary>  
    ///--------------------------------------------------------------------------------  
    protected void RunDiagnostics()  
    {  
        try  
        {   
            // set up diagnostics process  
            string solutionDir = System.IO.Path.GetDirectoryName(_applicationObject.Solution.FullName);  
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo(@"MyDiagnostics.exe", solutionDir);  
            procStartInfo.RedirectStandardOutput = true;  
            procStartInfo.UseShellExecute = false;  
            procStartInfo.CreateNoWindow = true;  
            System.Diagnostics.Process proc = new System.Diagnostics.Process();  
            proc.StartInfo = procStartInfo;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.OutputDataReceived += (object sendingProcess, DataReceivedEventArgs outLine)
                 => ShowOutput(String.Empty, outLine.Data, true, false);
 
            // execute the diagnostics  
            proc.Start();
            proc.BeginOutputReadLine();
        }  
        catch (Exception ex)  
        {  
            // put exception message in output pane  
            CustomPane.OutputString(ex.Message);  
        }  
    }  
