    public static class RunCommands
    {
        #region Outputs Property
        private static object _outputsLockObject;
        private static object OutputsLockObject
        { 
            get
            {
                if (_outputsLockObject == null)
                    Interlocked.CompareExchange(ref _outputsLockObject, new object(), null);
                return _outputsLockObject;
            }
        }
        private static Dictionary<object, CommandOutput> _outputs;
        private static Dictionary<object, CommandOutput> Outputs
        {
            get
            {
                if (_outputs != null)
                    return _outputs;
                lock (OutputsLockObject)
                {
                    _outputs = new Dictionary<object, CommandOutput>();
                }
                return _outputs;
            }
        }
        #endregion
        public static string GetCommandOutputSimple(ProcessStartInfo info, bool returnErrorIfPopulated = true)
        {
            // Redirect the output stream of the child process.
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            var process = new Process();
            process.StartInfo = info;
            process.ErrorDataReceived += ErrorDataHandler;
            process.OutputDataReceived += OutputDataHandler;
            var output = new CommandOutput();
            Outputs.Add(process, output);
            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            // Wait for the process to finish reading from error and output before it is finished
            process.WaitForExit();
            Outputs.Remove(process);
            if (returnErrorIfPopulated && (!String.IsNullOrWhiteSpace(output.Error)))
            {
                return output.Error.TrimEnd('\n');
            }
            return output.Output.TrimEnd('\n');
        }
        private static void ErrorDataHandler(object sendingProcess, DataReceivedEventArgs errLine)
        {
            if (errLine.Data == null)
                return;
            if (!Outputs.ContainsKey(sendingProcess))
                return;
            var commandOutput = Outputs[sendingProcess];
            commandOutput.Error = commandOutput.Error + errLine.Data + "\n";
        }
        private static void OutputDataHandler(object sendingProcess, DataReceivedEventArgs outputLine)
        {
            if (outputLine.Data == null)
                return;
            if (!Outputs.ContainsKey(sendingProcess))
                return;
            var commandOutput = Outputs[sendingProcess];
            commandOutput.Output = commandOutput.Output + outputLine.Data + "\n";
        }
    }
    public class CommandOutput
    {
        public string Error { get; set; }
        public string Output { get; set; }
        public CommandOutput()
        {
            Error = "";
            Output = "";
        }
    }
