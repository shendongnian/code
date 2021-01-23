        private static void runCommand(string cmdText) {
            //* Create your Process
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = cmdText;
            //* Set your output (asynchronous) handler
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            //* Start the process and the handler
            process.Start();
            process.BeginOutputReadLine(); 
            process.WaitForExit();
        }
        private static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine) {
            //* Do your stuff with the output (write to console/log/StringBuilder)
            Console.WriteLine(outLine.Data);
        }
