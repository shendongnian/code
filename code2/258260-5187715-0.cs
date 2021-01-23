        /// <summary>
        /// Collects standard output text from the launched program.
        /// </summary>
        private static readonly StringBuilder outputText = new StringBuilder();
        /// <summary>
        /// Collects standard error text from the launched program.
        /// </summary>
        private static readonly StringBuilder errorText = new StringBuilder();
        /// <summary>
        /// The program's entry point.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        /// <returns>The exit code.</returns>
        private static int Main(string[] args)
        {
            using (var process = Process.Start(new ProcessStartInfo(
                "program.exe",
                args)
                {
                    CreateNoWindow = true,
                    ErrorDialog = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }))
            {
                process.OutputDataReceived += (sendingProcess, outLine) =>
                    outputText.AppendLine(outLine.Data);
                process.ErrorDataReceived += (sendingProcess, errorLine) =>
                    errorText.AppendLine(errorLine.Data);
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                Console.WriteLine(errorText.ToString());
                Console.WriteLine(outputText.ToString());
                return process.ExitCode;
            }
