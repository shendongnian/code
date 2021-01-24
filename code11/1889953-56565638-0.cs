`
SetWindowPos(Process.MainWindowHandle, IntPtr.Zero, 0, 0, 0, 0, SetWindowPosFlags.IgnoreResize);
`
My code that works:
`
Process Process = new Process();
private void LuanchProceess(string path)
{
    // Try to acquire a the process.
    ProcessStartInfo startInfo = new ProcessStartInfo(path);
    try
    {
        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true;
        startInfo.WindowStyle = ProcessWindowStyle.Normal;
        Process.StartInfo = startInfo;
        Process.EnableRaisingEvents = true;
        Process.Exited += TabManagerContainerForm_ProcessExited;
        Process.Start();
        if (Process != null)
        {
            // Wait until the process has created a main window or exited.
            while (Process.MainWindowHandle == IntPtr.Zero && !Process.HasExited)
            {
                Thread.Sleep(100);
                Process.Refresh();
            }
            if (!Process.HasExited) // We have acquired a MainWindowHandle
            {
                // Capture the Process's main window and show it inside the applicationPanel panel control.
                SetParent(Process.MainWindowHandle, applicationPanel.Handle);
                // Change the captured Process's window to one without the standard chrome. Itʼs provided by our tabbed application.
                SetWindowLong(Process.MainWindowHandle, (int)WindowLongFlags.GWL_STYLE, (int)WindowStyles.WS_VISIBLE);
                SetWindowPos(Process.MainWindowHandle, IntPtr.Zero, 0, 0, 0, 0, SetWindowPosFlags.IgnoreResize);
                //SetWindowPos(Process.MainWindowHandle, IntPtr.Zero, 0, 0, applicationPanel.Width, applicationPanel.Height, 0);
            }
            else // Process has exited.
            {
                //if (Process.MainWindowHandle == IntPtr.Zero) Log.Information("{0} failed to execute.", Process.ProcessName);
                throw new Exception(string.Format("{0} failed to execute.", path));
            }
        }
        else
        {
            throw new Exception(string.Format("Invalid path: {0}", path));
        }
    }
    catch (Exception ex) when (!(ex is FailedProcessException)) // Catch everything but FailedProcessExceptions. FPEs are simply passed up the chain.
    {
        //Log.Error(ex.Message);
        throw;
    }
}
private void TabManagerContainerForm_ProcessExited(object sender, EventArgs e)
{
    throw new NotImplementedException();
}
`
