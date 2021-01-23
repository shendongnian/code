        public string ExecuteCmd()
        {
            try
            {
                string strReturn = "";
                string param = "";
                StreamReader standerOut;
                Process p = new Process();
                p.StartInfo.FileName = @"plink.exe";
                if (this.pass.Length == 0 || this.user.Length == 0 || this.host.Length == 0 || this.cmd.Length == 0)
                {
                    throw new Exception("SSHClient: Invalid parameteres for SSHClient.");
                }
                param = "-ssh -pw " + this.pass + " " + this.user + "@" + this.host + " " + this.cmd;
                string cd = Environment.CurrentDirectory;
                if (File.Exists("plink.exe") == false)
                {
                    throw new Exception("SSHClient: plink.exe not found. Make sure plink.exe is in the same folder as YOUR EXE.");
                }
                else
                {
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardInput = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.Arguments = param;
                    p.Start();
                    standerOut = p.StandardOutput;
                    
                    while (!p.HasExited)
                    {
                        if (!standerOut.EndOfStream)
                        {
                            strReturn += standerOut.ReadLine() + Environment.NewLine;
                            //textBox2.SelectionStart = textBox1.Text.Length;
                            //textBox2.ScrollToCaret();
                        }
                        // Application.DoEvents();
                    }                    
                }
                return strReturn;
            }
            catch (Exception exp)
            {
                throw new Exception("SSHClient:", exp);
            }
        }
