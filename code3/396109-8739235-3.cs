            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = exe_path;
            psi.Arguments = string.Format(@"-i ""{0}"" -y ""{1}""", 
                                               aac_path, mp3_path);
            psi.CreateNoWindow = true;
            psi.ErrorDialog = false;
            psi.UseShellExecute = false;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = false;
            psi.RedirectStandardError = true;
            Process exeProcess = Process.Start(psi);
            exeProcess.PriorityClass = ProcessPriorityClass.High;
            string outString = string.Empty;
            exeProcess.OutputDataReceived += (s, e) => {
                        outString += e.Data;
                    };
            exeProcess.BeginOutputReadLine();
            string errString = exeProcess.StandardError.ReadToEnd();
            Trace.WriteLine(outString);
            Trace.TraceError(errString);
            exeProcess.WaitForExit();
