    void foo()
    {
        System.Diagnostics.Process p = new System.Diagnostics.Process();
        p.StartInfo.FileName = "c:\\windows\\system32\\calc.exe";
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.UseShellExecute = false;
        p.EnableRaisingEvents = true;
        p.Exited += new EventHandler(p_Exited);
        p.Start();
    }           
    void p_Exited(object sender, EventArgs e)
    {
        System.Diagnostics.Process p = (System.Diagnostics.Process)sender;
        StreamReader sr = p.StandardOutput;
        while (!sr.EndOfStream)
        {
            string s = sr.ReadLine();
            // process s
        }
    }
