    ExportToExcel()
    {
        try
        {
            //your code
        }
       catch (Exception ex)
            {
            }
            finally
            {
                TryQuitExcel(Application_object);
            }
    }
    private static void TryQuitExcel(Microsoft.Office.Interop.Excel.Application  application)
            {
                try
                {
                    if (application != null &&
                      application.Workbooks != null &&
                      application.Workbooks.Count < 2)
                    {
                        application.DisplayAlerts = false;
                        application.Quit();
                        Kill(application.Hwnd);
                        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(application);
                        application = null;
                    }
                }
                catch
                {
                    /// Excel may have been closed via Windows Task Manager.
                    /// Skip the close.
                }
            }
        
    
     private static void Kill(int hwnd)
        {
            int excelPID = 0;
            int handle = hwnd;
            GetWindowThreadProcessId(handle, ref excelPID);
    
            Process process = null;
            try
            {
                process = Process.GetProcessById(excelPID);
    
                //
                // If we found a matching Excel proceess with no main window
                // associated main window, kill it.
                //
                if (process != null)
                {
                    if (process.ProcessName.ToUpper() == "EXCEL" && !process.HasExited)
                        process.Kill();
                }
            }
            catch { }
        }
       
     
