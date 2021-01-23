            // Start a new process for the cmd
            process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = FileName;
            process.StartInfo.Arguments = Arguments;
            process.StartInfo.WorkingDirectory = WorkingDirectory;
            process.Start();
            // Invoke stdOut and stdErr readers - each
            // has its own thread to guarantee that they aren't
            // blocked by, or cause a block to, the actual
            // process running (or the gui).
            new MethodInvoker(ReadStdOut).BeginInvoke(null, null);
            new MethodInvoker(ReadStdErr).BeginInvoke(null, null);
        }
        /// <summary>
        /// Handles reading of stdout and firing an event for
        /// every line read
        /// </summary>
        protected virtual void ReadStdOut()
        {
            string str;
            while ((str = process.StandardOutput.ReadLine()) != null)
            {
                FireAsync(StdOutReceived, this, new DataReceivedEventArgs(str));
            }
        }
        /// <summary>
        /// Handles reading of stdErr
        /// </summary>
        protected virtual void ReadStdErr()
        {
            string str;
            while ((str = process.StandardError.ReadLine()) != null)
            {
                FireAsync(StdErrReceived, this, new DataReceivedEventArgs(str));
            }
        }
