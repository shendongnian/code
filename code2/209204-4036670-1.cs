    class GetSchTasks {
    
        List<string> output = new List<string>();
    
        public void Run()
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = "SCHTASKS.exe";
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    
    
            string MachineName = "CHESTNUT105b";
            string ScheduledTaskName = "Calculator";
            string activeDirectoryDomainName = "xxx";
            string userName = "xxx";
            string password = "xxxxx";
    
            p.StartInfo.Arguments = String.Format("/Query /S {0} /FO LIST", MachineName);
    
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
            p.WaitForExit();
            p.Close();
            p.Dispose();
    
        }
    
        void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            //Handle errors here
        }
        
        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            output.Add(e.Data);
        }
    
    }
