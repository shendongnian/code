            var outputText = new StringBuilder();
            var errorText = new StringBuilder();
            using (var process = Process.Start(new ProcessStartInfo(
                @"YourProgram.exe",
                "arguments go here")
                {
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }))
            {
                process.OutputDataReceived += (sendingProcess, outLine) =>
                {
                    outputText.AppendLine(outLine.Data); // capture the output
                    Console.Out.WriteLine(outLine.Data); // echo the output
                }
                process.ErrorDataReceived += (sendingProcess, errorLine) =>
                {
                    errorText.AppendLine(errorLine.Data); // capture the error
                    Console.Error.WriteLine(errorLine.Data); // echo the error
                }
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                // At this point, errorText and outputText StringBuilders
                // have the captured text.  The event handlers already echoed the
                // output back to the console.
            }
