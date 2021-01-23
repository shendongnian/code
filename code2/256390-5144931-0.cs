    /// <summary>
    /// Reads streams from a process's <see cref="Process.StandardOutput"/> and <see cref="Process.StandardError"/>
    /// streams.
    /// </summary>
    public class ProcessOutputReader
    {
        /// <summary>
        /// Builds the combined output of StandardError and StandardOutput.
        /// </summary>
        private readonly StringBuilder combinedOutputBuilder = new StringBuilder();
        /// <summary>
        /// Object that is locked to control access to <see cref="combinedOutputBuilder"/>.
        /// </summary>
        private readonly object combinedOutputLock = new object();
        /// <summary>
        /// Builds the error output string.
        /// </summary>
        private readonly StringBuilder errorOutputBuilder = new StringBuilder();
        /// <summary>
        /// The <see cref="Process"/> that this instance is reading.
        /// </summary>
        private readonly Process process;
        /// <summary>
        /// Builds the standard output string.
        /// </summary>
        private readonly StringBuilder standardOutputBuilder = new StringBuilder();
        /// <summary>
        /// Flag to record that we are already reading asynchronously (only one form is allowed).
        /// </summary>
        private bool readingAsync;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessOutputReader"/> class.
        /// </summary>
        /// <param name="process">
        /// The process.
        /// </param>
        public ProcessOutputReader(Process process)
        {
            if (process == null)
            {
                throw new ArgumentNullException("process");
            }
            this.process = process;
        }
        /// <summary>
        /// Gets the combined output of StandardOutput and StandardError, interleaved in the correct order.
        /// </summary>
        /// <value>The combined output of StandardOutput and StandardError.</value>
        public string CombinedOutput { get; private set; }
        /// <summary>
        /// Gets the error output.
        /// </summary>
        /// <value>
        /// The error output.
        /// </value>
        public string StandardError { get; private set; }
        /// <summary>
        /// Gets the standard output.
        /// </summary>
        /// <value>
        /// The standard output.
        /// </value>
        public string StandardOutput { get; private set; }
        /// <summary>
        /// Begins the read process output.
        /// </summary>
        public void BeginReadProcessOutput()
        {
            if (this.readingAsync)
            {
                throw new InvalidOperationException("The process output is already being read asynchronously");
            }
            this.readingAsync = true;
            this.CheckProcessRunning();
            this.process.OutputDataReceived += this.OutputDataReceived;
            this.process.ErrorDataReceived += this.ErrorDataReceived;
            this.process.BeginOutputReadLine();
            this.process.BeginErrorReadLine();
        }
        /// <summary>
        /// Ends asynchronous reading of process output.
        /// </summary>
        public void EndReadProcessOutput()
        {
            if (!this.process.HasExited)
            {
                this.process.CancelOutputRead();
                this.process.CancelErrorRead();
            }
            this.process.OutputDataReceived -= this.OutputDataReceived;
            this.process.ErrorDataReceived -= this.ErrorDataReceived;
            this.StandardOutput = this.standardOutputBuilder.ToString();
            this.StandardError = this.errorOutputBuilder.ToString();
            this.CombinedOutput = this.combinedOutputBuilder.ToString();
        }
        /// <summary>
        /// Reads the process output.
        /// </summary>
        public void ReadProcessOutput()
        {
            if (this.readingAsync)
            {
                throw new InvalidOperationException("The process output is already being read asynchronously");
            }
            this.BeginReadProcessOutput();
            this.process.WaitForExit();
            this.EndReadProcessOutput();
        }
        /// <summary>
        /// Appends a line of output to the specified builder and to the combined output.
        /// </summary>
        /// <param name="builder">The target builder.</param>
        /// <param name="line">The line of output.</param>
        private void AppendLine(StringBuilder builder, string line)
        {
            builder.AppendLine(line);
            lock (this.combinedOutputLock)
            {
                this.combinedOutputBuilder.AppendLine(line);
            }
        }
        /// <summary>
        /// Checks that the process is running.
        /// </summary>
        private void CheckProcessRunning()
        {
            // process.Handle will itself throw an InvalidOperationException if the process hasn't been started.
            if (this.process.HasExited)
            {
                throw new InvalidOperationException("Process has exited");
            }
        }
        
        /// <summary>
        /// Handles the ErrorDataReceived event on the monitored process.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Diagnostics.DataReceivedEventArgs"/> instance containing the event data.</param>
        private void ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                this.AppendLine(this.errorOutputBuilder, e.Data);
            }
        }
        /// <summary>
        /// Handles the OutputDataReceived event on the monitored process.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Diagnostics.DataReceivedEventArgs"/> instance containing the event data.</param>
        private void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                this.AppendLine(this.standardOutputBuilder, e.Data);
            }
        }
    }
