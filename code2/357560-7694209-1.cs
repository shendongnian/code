    static void Main(string[] args)
    {
        string cName = "";
    
        var xlApp = new Application();
    
        var xlWB = xlApp.Workbooks.Open("youpathgoeshere", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        xlApp.Calculation = XlCalculation.xlCalculationManual;
    
        var xlWS = new Worksheet();
    
        xlWB.SaveAs("vFile.html", Microsoft.Office.Interop.Excel.XlFileFormat.xlHtml);
        cName = xlWB.FullName;
        xlWB.Close();
    
        xlApp.Quit();
    
    }
