    if (s.Contains("mp4:production/CATCHUP/"))
    {
       RemoveEXELog();
       Process p = new Process();
       p.StartInfo.WorkingDirectory = "dump";
       p.StartInfo.FileName = "test.exe"; 
       p.StartInfo.Arguments = s; 
       p.Start();
       break;
    }
