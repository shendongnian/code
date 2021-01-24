cs
static string GetStoreAppVersion(string appName)
{
    var process = new Process
    {
        StartInfo =
        {
            FileName = "powershell.exe",
            Arguments = $"-Command (Get-AppxPackage \"{appName}\" | Select Version).Version",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        }
    };
    process.Start();
    process.WaitForExit();
    var output = process.StandardOutput.ReadToEnd();
    var version = output.Replace(System.Environment.NewLine, string.Empty);
    if (string.IsNullOrWhiteSpace(version))
    {
        return null;
    }
    return version;
}
