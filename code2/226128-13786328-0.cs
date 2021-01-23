    public static Window GetWpfMainWindow(this EnvDTE.DTE dte)
    {
      if (dte == null)
      {
        throw new ArgumentNullException("dte");
      }
      var hwndMainWindow = (IntPtr)dte.MainWindow.HWnd;
      if (hwndMainWindow == IntPtr.Zero)
      {
        throw new NullReferenceException("DTE.MainWindow.HWnd is null.");
      }
      var hwndSource = HwndSource.FromHwnd(hwndMainWindow);
      if (hwndSource == null)
      {
        throw new NullReferenceException("HwndSource for DTE.MainWindow is null.");
      }
      return (Window) hwndSource.RootVisual;
    }
