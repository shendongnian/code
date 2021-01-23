    Excel.Application xlApp = new Excel.Application();
    xlApp.Visible = true;
    xlApp.Workbooks.Add(System.Type.Missing);  
    Excel.Worksheet active = (Excel.Worksheet)xlApp.ActiveSheet;
    xlApp.DefaultSheetDirection = (int)Excel.Constants.xlLTR; //or xlRTL
    active.DisplayRightToLeft = false;
