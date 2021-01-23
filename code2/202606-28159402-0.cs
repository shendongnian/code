    protected bool checkDNS(string host, string recType = "MX")
    {
        bool result = false;
        try
        {
            using (Process proc = new Process())
            {
                proc.StartInfo.FileName = "nslookup";
                proc.StartInfo.Arguments = string.Format("-type={0} {1}", recType, host);
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.ErrorDialog = false;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                    {
                        if ((e.Data != null) && (!result))
                            result = e.Data.StartsWith(host);
                    };
                proc.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                    {
                        if (e.Data != null)
                        {
                            //read error output here, not sure what for?
                        }
                    };
                proc.Start();
                proc.BeginErrorReadLine();
                proc.BeginOutputReadLine();
                proc.WaitForExit(30000); //timeout after 30 seconds.
            }
        }
        catch
        {
            result = false;
        }
        return result;
    }
