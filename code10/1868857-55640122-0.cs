    string pathToTheVersionOfExcel "...";
    int amountOfTimeToWaitForFailure = 5000;
    
    Process process = new Process();
    process.StartInfo.FileName = pathToTheVersionOfExcel;
    process.Start();
    
    Thread.Sleep(amountOfTimeToWaitForFailure);
    
    oExcelApp = (_Application)Marshal.GetActiveObject("Excel.Application");
