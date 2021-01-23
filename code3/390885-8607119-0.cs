            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.Domain = "domain";
            pProcess.StartInfo.UserName = "user with priv";
            pProcess.StartInfo.Password = new System.Security.SecureString();
            char [] pass = textBox3.Text.ToArray();
            for (int x = 0; x < pass.Length; ++x)
            {
                pProcess.StartInfo.Password.AppendChar(pass[x]);
            }
            pProcess.StartInfo.FileName = @"psexec.exe";
            pProcess.StartInfo.Arguments = @"\\remoteHost netstat -ano";
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardInput = true;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.RedirectStandardError = true;
            pProcess.Start();
            pProcess.WaitForExit(30000);
            if (!pProcess.HasExited)
            {
                pProcess.Kill();
            }
            string strOutput = pProcess.StandardOutput.ReadToEnd();
            string errOutput = pProcess.StandardError.ReadToEnd();
            textBox1.Text = strOutput;
            textBox2.Text = errOutput;
