            using (Process p = new Process())
            {
                p.StartInfo.UseShellExecute = false;                
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.OutputDataReceived += (sender, args) => Debug.WriteLine("STDOUT: " + args.Data);
                p.ErrorDataReceived += (sender, args) => Debug.WriteLine("STDERR:" + args.Data);
                p.StartInfo.FileName = exePath;
                p.StartInfo.Arguments = parameters;
                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit(30 * 1000);
                              
                if (!p.HasExited)
                {
                    Debug.WriteLine("Killing process");
                    p.Kill();
                }
                
            }
