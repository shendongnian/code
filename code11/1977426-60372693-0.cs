    string headerName ="two";
    Excel.Worksheet sh = (Excel.Worksheet) excelApp.ActiveSheet;
    Excel.Range headerRow = (Excel.Range) sh.UsedRange.Rows[1];
    Excel.Range col = null;
    foreach(Excel.Range cel in headerRow.Cells)
    {
        if (cel.Text.ToString().Equals(headerName))
        {
            col = sh.Range[cel.Address, cel.End[Excel.XlDirection.xlDown]];
            break;
        }
    }
    foreach(Excel.Range cellInCol in col)
    {
        Debug.Print(cellInCol.Value2.ToString());
    }
