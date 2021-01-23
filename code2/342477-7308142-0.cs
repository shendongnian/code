    Process[] Prs = Process.GetProcessesByName(RunninExe);
    if (Prs.Length > 0)
    {
          foreach (Process Prss in Prs)
          {
              Prss.Kill();
          }
    }
