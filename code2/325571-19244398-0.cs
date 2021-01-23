    public string GetMacAddress(string ipAddress)
            {
                string macAddress = string.Empty;
                System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
                pProcess.StartInfo.FileName = "arp";
                pProcess.StartInfo.Arguments = "-a " + ipAddress;
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                 pProcess.StartInfo.CreateNoWindow = true;
                pProcess.Start();
                string strOutput = pProcess.StandardOutput.ReadToEnd();
                string[] substrings = strOutput.Split('-');
                if (substrings.Length >= 8)
                {
                    macAddress = substrings[4] + "-" + substrings[5] + "-" + substrings[6] + "-" + substrings[7] + "-" +
                              substrings[8].Substring(0, 2);
                    return macAddress;
                }
    
                else
                {
                    return "not found";
                }
            }
