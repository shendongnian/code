        /// <summary>
        /// Execute external process.
        /// Block until process has terminated.
        /// Capture output.
        /// </summary>
        /// <param name="binaryFilename"></param>
        /// <param name="arguments"></param>
        /// <param name="currentDirectory"></param>
        /// <param name="priorityClass">Priority of started process.</param>
        /// <returns>stdout output.</returns>
        public static string ExecuteProcess(string binaryFilename, string arguments, string currentDirectory, ProcessPriorityClass priorityClass)
        {
            if (String.IsNullOrEmpty(binaryFilename))
            {
                return "no command given.";
            }
            Process p = new Process();
            p.StartInfo.FileName = binaryFilename;
            p.StartInfo.Arguments = arguments;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            if (!String.IsNullOrEmpty(currentDirectory))
                p.StartInfo.WorkingDirectory = currentDirectory;
            p.StartInfo.CreateNoWindow = false;
            p.Start();
            // Cannot set priority process is started.
            p.PriorityClass = priorityClass;
            // Must have the readToEnd BEFORE the WaitForExit(), to avoid a deadlock condition
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            if (p.ExitCode != 0)
            {
                throw new Exception(String.Format("Process '{0} {1}' ExitCode was {2}",
                                     binaryFilename,
                                     arguments,
                                     p.ExitCode));   
            }
            //string standardError = p.StandardError.ReadToEnd();
            //if (!String.IsNullOrEmpty(standardError))
            //{
            //    throw new Exception(String.Format("Process '{0} {1}' StandardError was {2}",
            //                         binaryFilename,
            //                         arguments,
            //                         standardError));
            //}
            return output;
        }
