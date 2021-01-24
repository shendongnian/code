lang-csharp
void StartProcess()
{
    Process nodeProcess = new Process();
    ProcessStartInfo startInfo = new ProcessStartInfo();
    startInfo.FileName = "node.exe";
    startInfo.Arguments = @"path" + " arg1 arg2 arg3";
    startInfo.UseShellExecute = false;
    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    startInfo.RedirectStandardOutput = true;
    nodeProcess.StartInfo = startInfo;
    nodeProcess.EnableRaisingEvents = true;
    nodeProcess.Exited += nodeProcess_Exited;
    nodeProcess.OutputDataReceived += nodeProcess_OutputDataReceived;
    nodeProcess.Start();
    nodeProcess.BeginOutputReadLine();
}
void nodeProcess_Exited(object sender, EventArgs e)
{
    // Do something when the process exits, if you need to.
    // You'll want to check InvokeRequired before you modify any of your form's controls.
}
void nodeProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
{
    if (txt_log.InvokeRequired)
    {
        txt_log.Invoke(new Action<string>(AddText), new object[] { e.Data });
        return;
    }
    txt_log.Text += "\n " + e.Data;
}
