    public DataSet GetExcelData()
    {
        DataTable ExcelTable = new DataTable();
        List<DataRow> rowToRemove = new List<DataRow>();
        foreach (DataRow excelrow in dsExcel.Tables[0].Rows)
        {
            foreach (object item in excelrow.ItemArray)
            {
                if (String.IsNullOrEmpty(item.ToString())) 
                {
                     rowToRemove.Add(excelRow);
                     break;
                }                  
            }
        }
        foreach (DataRow row in rowToRemove)
        {
            dsExcel.Tables[0].Rows.Remove(rowToRemove[i]);
        }
        return dsExcel;
    }
