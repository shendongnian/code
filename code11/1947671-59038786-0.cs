    using System.Diagnostics;
        //class lvl scope vars
        string output;
        string ErrorOutput;
        private void MapNetwork_Click(object sender, EventArgs e)
        {
            //define process arguments
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"cmd.exe";
            startInfo.Arguments = @"FQDN path to your file on the server; exit";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            //start process
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            //outpunt handling
            if (string.IsNullOrEmpty(ErrorOutput))
            {
                return output;
            }
            else
            {
                return ErrorOutput;
            }
        }
