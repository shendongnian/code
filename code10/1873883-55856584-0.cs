/// <summary>
/// Check if this process is running on Windows in an in process instance in IIS
/// </summary>
/// <returns>True if Windows and in an in process instance on IIS, false otherwise</returns>
public static bool IsRunningInProcessIIS()
{
    if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    {
        return false;
    }
    string processName = Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().ProcessName);
    return (processName.Contains("w3wp", StringComparison.OrdinalIgnoreCase) ||
        processName.Contains("iisexpress", StringComparison.OrdinalIgnoreCase));
}
