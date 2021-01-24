System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses("Excel");    
foreach (Process p in processes)
{
  if (p.MainWindowTitle == "MyFile.xlsx - Excel")
  {
    int hwnd = 0;
    //Get a handle for the Application main window
    hwnd = FindWindow(null, p.MainWindowTitle);
    //send WM_CLOSE system message
    if (hwnd != 0)
      SendMessage(hwnd, WM_CLOSE, 0, IntPtr.Zero); 
    
    break;
  }
}
