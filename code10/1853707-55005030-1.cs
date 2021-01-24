    List<int> HiddenWindows = new List<int>();
    private void btnHide_Click(object sender, RoutedEventArgs e)
    {
      Process[] processRunning = Process.GetProcessesByName(FileName);
      foreach (Process pr in processRunning)
      {
        int hWnd = pr.MainWindowHandle.ToInt32();
        if (hWnd == 0)
          continue;
        ShowWindow(hWnd, SW_HIDE);
        HiddenWindows.Add(hWnd);
      }
    }
    private void btnShow_Click(object sender, RoutedEventArgs e)
    {
      foreach (int hWnd in HiddenWindows)
      {
        ShowWindow(hWnd, SW_SHOW);
      }
      HiddenWindows.Clear();
    }
