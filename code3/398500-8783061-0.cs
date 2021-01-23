    foreach (Process proc in processlist)
    {
      try
      {
        Console.WriteLine(proc.MainModule.FileName);
      }
      catch (Win32Exception e)
      {
         Console.WriteLine(proc.ToString() + "  " + e.Message);
      }
    }
