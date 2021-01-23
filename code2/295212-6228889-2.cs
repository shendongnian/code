    public string Convert(string source)
    {
        string processName = @"C:\Program Files\Pandoc\bin\pandoc.exe";
        string args = String.Format(@"-r html -t mediawiki");
        ProcessStartInfo psi = new ProcessStartInfo(processName, args);
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardInput = true;
        Process p = new Process();
        p.StartInfo = psi;
        psi.UseShellExecute = false;
        p.Start();
        string outputString = "";
        byte[] inputBuffer = ASCIIEncoding.UTF8.GetBytes(source);
        p.StandardInput.BaseStream.Write(inputBuffer, 0, inputBuffer.Length);
        p.StandardInput.Close();
        System.Threading.Thread.Sleep(2000);
        using (System.IO.StreamReader sr = new System.IO.StreamReader(
                                               p.StandardOutput.BaseStream))
        {
        	
            outputString = sr.ReadToEnd();
        }
        return outputString;
    }
