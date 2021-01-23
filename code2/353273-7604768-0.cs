    protected string RunProcess(string Parameters)
    {
        //create a process info
        var oInfo = new ProcessStartInfo(this.FFmpegLocation, Parameters)
        {
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        var output = string.Empty;
       
        try
        {                
            Process process = System.Diagnostics.Process.Start(oInfo);
            output = process.StandardError.ReadToEnd();
            process.WaitForExit();
            process.Close();
        }
        catch (Exception)
        {
            output = string.Empty;
        }                       
        return output;
    }
