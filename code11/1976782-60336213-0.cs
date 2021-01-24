        private static void VerifyDocker()
        {
            var processStartInfo = new ProcessStartInfo();
            var messagesBuilder = new StringBuilder();
            var errorMessagesBuilder = new StringBuilder();
            var arguments = "info --format \"{{json .}}\"";
            using (var process = new Process())
            {
                processStartInfo.FileName = "docker";
                processStartInfo.Arguments = arguments;
                processStartInfo.CreateNoWindow = true;
                processStartInfo.UseShellExecute = false;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.RedirectStandardError = true;
                process.OutputDataReceived += (sender, e) => messagesBuilder.Append(e.Data);
                process.ErrorDataReceived += (sender, e) => errorMessagesBuilder.Append(e.Data);
                process.StartInfo = processStartInfo;
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                process.CancelOutputRead();
                process.CancelErrorRead();
                var message = messagesBuilder.ToString();
                var errrors = errorMessagesBuilder.ToString();
            }
        }
