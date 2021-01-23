    Microsoft.Office.Interop.Excel.Application xlApp;
    xlApp = new Microsoft.Office.Interop.Excel.Application();
    if (xlApp == null)
    {
       Console.WriteLine("EXCEL could not be started. Check that your office installation and project references are correct.");
    }
