bool TestProcess()
{
    var process = Process.Start("notepad");
    try
    {
        for (var attempt = 0; attempt < 20; ++attempt)
        {
            if (process?.MainWindowHandle != IntPtr.Zero)
            {
                return true;
            }
            Thread.Sleep(100);
            process = Process.GetProcessById(process.Id);
        }
        return false;
    }
    finally
    {
        process?.Kill();
    }
}
