private string ProcessRunner()
{
    ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
    processStartInfo.RedirectStandardInput = true;
    processStartInfo.RedirectStandardOutput = true;
    processStartInfo.UseShellExecute = false;
    Process process = Process.Start(processStartInfo);
    
    if (process != null)
    {
        process.StandardInput.WriteLine("dir");
        process.StandardInput.WriteLine("mkdir testDir");
        process.StandardInput.WriteLine("echo hello");
        //process.StandardInput.WriteLine("yourCommand.exe arg1 arg2");
        string outputString = process.StandardOutput.ReadToEnd();
        return outputString;
    }
    return string.Empty;
}
