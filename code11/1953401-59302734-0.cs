cs
bool error = false;
string errorMsg = String.Empty;
public static void Main()
{
    try
    {
        using (Process process = CreateProcess())
        {
            process.Start();
            process.BeginErrorReadLine();
            process.WaitForExit();
            if (error)
            {
                throw new Exception(errorMsg);
            }
        }   
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
private static Process CreateProcess()
{
    Process process = new Process();
    process.ErrorDataReceived += ActionOnErrorDataReceived;
    return process;
}
private static void ActionOnErrorDataReceived(object sender, DataReceivedEventArgs e)
{
    error = true;
    errorMsg = e?.Data;
    Process p = (sender as Process);
    if (p != null && p.HasExited == false)
    {
        p.Kill();
    }
}
