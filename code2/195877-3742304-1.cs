    using System;
    using System.Diagnostics;
    Process process = Process.Start(new ProcessStartInfo("bash", path_to_script) {
                                        UseShellExecute = false,
                                        RedirectStandardOutput = true
                                    });
    string output = process.StandardOutput.ReadToEnd();
    process.WaitForExit();
    if (process.ExitCode != 0) { … /*the process exited with an error code*/ }
