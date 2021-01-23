    Excel.Application oXL= new Excel.Application();
    oXL.Visible = true;
    Excel._Workbook oWB = (Excel._Workbook)(oXL.Workbooks.Add( Missing.Value ));
    Excel._Worksheet oSheet = (Excel._Worksheet)oWB.ActiveSheet;
    string s = (string)oSheet.Cells[1, 1].Value;
