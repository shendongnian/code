    using System.Diagnostics;
    using NUnit.Framework;
    private static void ExecuteWAStorageEmulator(string argument)
    {
        var start = new ProcessStartInfo
        {
            Arguments = argument,
            FileName = @"c:\Program Files (x86)\Microsoft SDKs\Windows Azure\Storage Emulator\WAStorageEmulator.exe"
        };
        var exitCode = ExecuteProcess(start);
        Assert.AreEqual(exitCode, 0, "Error {0} executing {1} {2}", exitCode, start.FileName, start.Arguments);
    }
    private static int ExecuteProcess(ProcessStartInfo start)
    {
        int exitCode;
        using (var proc = new Process { StartInfo = start })
        {
            proc.Start();
            proc.WaitForExit();
            exitCode = proc.ExitCode;
        }
        return exitCode;
    }
