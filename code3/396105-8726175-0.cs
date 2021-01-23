            internal void ConvertFile(string inputFileName, Guid taskID)
        {
            string tmpName = string.Format(
                "{0}\\{1}.flv",
                Path.GetTempPath(), inputFileName.Substring(inputFileName.LastIndexOf("\\")+1));
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = this._processorExecutable;
            psi.Arguments = string.Format(@"-i ""{0}"" -y ""{1}""", inputFileName, tmpName);
            psi.CreateNoWindow = true;
            psi.ErrorDialog = false;
            psi.UseShellExecute = false;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = false;
            psi.RedirectStandardError = true;
            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(psi))
                {
                    exeProcess.PriorityClass = ProcessPriorityClass.High;
                    string outString = string.Empty;
                    // use ansynchronous reading for at least one of the streams
                    // to avoid deadlock
                    exeProcess.OutputDataReceived += (s, e) => {
                        outString += e.Data;
                    };
                    exeProcess.BeginOutputReadLine();
                    // now read the StandardError stream to the end
                    // this will cause our main thread to wait for the
                    // stream to close (which is when ffmpeg quits)
                    string errString = exeProcess.StandardError.ReadToEnd();
                    Trace.WriteLine(outString);
                    Trace.TraceError(errString);
                    byte[] fileBytes = File.ReadAllBytes(tmpName);
                    if (fileBytes.Length > 0)
                    {
                        this._sSystem.SaveOutputFile(
                            fileBytes, 
                            tmpName.Substring(tmpName.LastIndexOf("\\")+1),
                            taskID
                            );
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
            }
        }
