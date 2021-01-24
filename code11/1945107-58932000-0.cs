        ProcessStartInfo p = new ProcessStartInfo
                    {
                        FileName = "sh",
                        Arguments = "/home/pi/ConnectCapture/upload.sh " + file
                    };
    p.RedirectStandardOutput = true;
                    p.RedirectStandardError = true;
                    p.UseShellExecute = false;
                    p.CreateNoWindow = false;
                    Process proc1 = new Process();
                    proc1.StartInfo = p;
                    proc1.Start();
                    string result = "";
                    using (System.IO.StreamReader output = proc1.StandardOutput) {
                        result = output.ReadToEnd();
                    }
                    string error = "";
                    using (System.IO.StreamReader output = proc1.StandardError)
                    {
                        error = output.ReadToEnd();
                    }
    
                    log.InfoFormat("SFTP result: {0}", result);
                    log.InfoFormat("{0}", error);
