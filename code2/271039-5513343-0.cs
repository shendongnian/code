    private void TestMethod()
    {
       bool excelWasRunning = System.Diagnostics.Process.GetProcessesByName("excel").Length > 0;
    
       // your code
       if (!excelWasRunning)
       { 
           xlApp.Quit();
       }
    }
