    public void addTime(Microsoft.Office.Interop.Excel.Workbook workbook)  
    {  
    Excel.Worksheet ws = (Excel.Worksheet)workbook.Worksheets.get_Item("Time Series");  
    Excel.Range range = ws.UsedRange;  
    int num = 0;  
    for (int row = 1; row <= range.Rows.Count; row++ )  
    {  
        String dtString = ((Excel.Range)ws.Cells[row, "C"]).Value2.ToString();  
        DateTime dt = DateTime.Parse(ConvertToDateTime(dtString));  
  
        this.addEdgeInstance(dt);  
    }  
    }  
    public static string ConvertToDateTime(string strExcelDate)
    {
        double excelDate;
        try
        {
            excelDate = Convert.ToDouble(strExcelDate);
        }
        catch
        {
            return strExcelDate;
        }
        if (excelDate < 1)
        {
            throw new ArgumentException("Excel dates cannot be smaller than 0.");
        }
        DateTime dateOfReference = new DateTime(1900, 1, 1);
        if (excelDate > 60d)
        {
            excelDate = excelDate - 2;
        }
        else
        {
            excelDate = excelDate - 1;
        }
        return dateOfReference.AddDays(excelDate).ToShortDateString();
    }
