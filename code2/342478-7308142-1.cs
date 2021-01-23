    Process[] Prs = Process.GetProcessesById(RunninExe);
    if (Prs.Length > 0)
    {
          foreach (Process Prss in Prs)
          {
              Prss.Kill();
          }
    }
