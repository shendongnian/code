        Thread t = new Thread(ReadStart);
        t.Start(process);
        process.WaitForExit();
    public void ReadStart(object data)
    {
      System.Diagnostics.Process p = (System.Diagnostics.Process)data;
      while(true)
      {
        string s  = p.StandardOutput.ReadToEnd();
        textBox1.AppendText(s);
        Thread.Sleep(1000);
        if (p.HasExited) break;
      }
    }
