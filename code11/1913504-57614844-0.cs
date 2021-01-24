public static void ExecuteShellCommand(string command)
{
    var ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + command)
    {
        WindowStyle = ProcessWindowStyle.Hidden,
        CreateNoWindow = true,
        UseShellExecute = true
    };
    Process.Start(ProcessInfo);
}
