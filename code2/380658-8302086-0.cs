    System.Diagnostics.Process[] myProcesses;
    // Returns array containing all instances of Excel.
    myProcesses = System.Diagnostics.Process.GetProcessesByName("Excel");
    foreach (System.Diagnostics.Process myProcess in myProcesses)
    {
        if (myProcess.MainWindowTitle == Globals.ThisWorkbook.Application.Caption)
        {
            myProcess.Kill();
        }
    }
