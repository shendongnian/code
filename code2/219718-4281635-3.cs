    var process = Process.Start(new ProcessStartInfo
                            {
                                Verb = "runas",
                                FileName = typeof(RunService).Assembly.Location,
                                UseShellExecute = true,
                                CreateNoWindow = true,
                            });
    process.WaitForExit();
    var exitCode = process.ExitCode
    // TODO process exit code...
