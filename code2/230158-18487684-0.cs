    Aspose.Cells.LoadOptions loadOptions = new Aspose.Cells.LoadOptions(Aspose.Cells.LoadFormat.CSV);
    Workbook workbook = new Workbook(fstream, loadOptions);
    Worksheet worksheet = workbook.Worksheets[0];
    
    dt = worksheet.Cells.ExportDataTable(0, 0, worksheet.Cells.MaxDisplayRange.RowCount, worksheet.Cells.MaxDisplayRange.ColumnCount, true);
    
    DataTable dtCloned = dt.Clone();
    ArrayList myAL = new ArrayList();
    
    foreach (DataColumn column in dtCloned.Columns)
    {
    	if (column.DataType == Type.GetType("System.DateTime"))
    	{
    		column.DataType = typeof(String);
    		myAL.Add(column.ColumnName);
    	}
    }
    
    
    foreach (DataRow row in dt.Rows)
    {
    	dtCloned.ImportRow(row);
    }
    
    
    
    foreach (string colName in myAL)
    {
    	dtCloned.Columns[colName].Convert(val => DateTime.Parse(Convert.ToString(val)).ToString("MMMM dd, yyyy"));
    }
    
    
    /*******************************/
    
    public static class MyExtension
    {
        public static void Convert<T>(this DataColumn column, Func<object, T> conversion)
        {
            foreach (DataRow row in column.Table.Rows)
            {
                row[column] = conversion(row[column]);
            }
        }
    }
