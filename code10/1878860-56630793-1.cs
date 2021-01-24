    private static void KillSpecificExcelFileProcess(string excelFileName)
    {
        var processes = from p in Process.GetProcessesByName("EXCEL")
                        select p;
    
        foreach (var process in processes)
        {
            if (process.MainWindowTitle == excelFileName.Substring(0, excelFileName.IndexOf(".")) + " - Excel" )
                process.Kill();
        }
    }
