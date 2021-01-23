    [DllImport("user32")]
    public static extern int EnumWindows(EnumWindowsDelegate CallBack, 
                                         List<ProcessModel> Processes);
    [DllImport("user32")]
    internal static extern int GetAncestor(int hwnd, int gaFlags);
    [DllImport("user32")]
    internal static extern int GetLastActivePopup(int hWnd);
    [DllImport("user32")]
    internal static extern bool IsWindowVisible(int hWnd);
    internal delegate bool EnumWindowsDelegate(int Hwnd, List<ProcessModel> Processes);
    internal static bool EnumWindowsCallBack(int Hwnd, List<ProcessModel> Processes)
    {
      // Visible != Minimized (I think)
      if (!IsWindowVisible(Hwnd))
        return true;
      // Can the Window be shown by using alt-tab
      if (IsAltTabWindow(Hwnd))
      {
        ProcessModel model = new ProcessModel();
        model.WindowsHandle = Hwnd;
        try
        {
          int pid = 0;
          GetWindowThreadProcessId(Hwnd, out pid);
          if (pid > 0)
          {
            string filename = string.Empty;
            try
            {
              model.ProcessID = pid;
              Process p = Process.GetProcessById(pid);
              if (p != null)
              {
                filename = p.MainModule.FileName;
                filename = System.IO.Path.GetFileName(filename);
                model.Filename = filename;
                if (filename.Contains("explorer.exe"))
                {
                  model.IsWindowsExplorer = true;
                }
                Processes.Add(model);
              }
            }
            // Do something or not, 
            // catch probably if window process is closed while querying info
            catch { }
          }
        }
            // Do something or not, 
            // catch probably if window process is closed while querying info
        catch { }
      }
      return true;
    }
    internal static bool IsAltTabWindow(int hwnd)
    {
      // Start at the root owner
      int hwndWalk = GetAncestor(hwnd, 3);
      // See if we are the last active visible popup
      int hwndTry;
      while ((hwndTry = GetLastActivePopup(hwndWalk)) != hwndTry)
      {
        if (IsWindowVisible(hwndTry)) 
          break;
        hwndWalk = hwndTry;
      }
      return hwndWalk == hwnd;
    }
    public List<ProcessModel> GetProccesses()
    {
      List<ProcessModel> processes = new List<ProcessModel>()
      EnumWindowsDelegate enumCallback = new EnumWindowsDelegate(EnumWindowsCallBack);
      EnumWindows(enumCallback, processes);
      return processes;
    }
