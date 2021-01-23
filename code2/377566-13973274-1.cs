    public static class My_DataTable_Extensions
    {
    
    	// Export DataTable into an excel file with field names in the header line
    	// - Save excel file without ever making it visible if filepath is given
    	// - Don't save excel file, just make it visible if no filepath is given
    	public static void ExportToExcel(this DataTable Tbl, string ExcelFilePath = null)
    	{
    		try
    		{
    			if (Tbl == null || Tbl.Columns.Count == 0)
    				throw new Exception("ExportToExcel: Null or empty input table!\n");
    
    			// load excel, and create a new workbook
    			Excel.Application excelApp = new Excel.Application();
    			excelApp.Workbooks.Add();
    
    			// single worksheet
    			Excel._Worksheet workSheet = excelApp.ActiveSheet;
    
    			// column headings
    			for (int i = 0; i < Tbl.Columns.Count; i++)
    			{
    				workSheet.Cells[1, (i+1)] = Tbl.Columns[i].ColumnName;
    			}
    
    			// rows
    			for (int i = 0; i < Tbl.Rows.Count; i++)
    			{
    				// to do: format datetime values before printing
    				for (int j = 0; j < Tbl.Columns.Count; j++)
    				{
    					workSheet.Cells[(i + 2), (j + 1)] = Tbl.Rows[i][j];
    				}
    			}
    			// check fielpath
    			if (ExcelFilePath != null && ExcelFilePath != "")
    			{
    				try
    				{
    					workSheet.SaveAs(ExcelFilePath);
    					excelApp.Quit();
    					MessageBox.Show("Excel file saved!");
    				}
    				catch (Exception ex)
    				{
    					throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
    						+ ex.Message);
    				}
    			}
    			else    // no filepath is given
    			{
    				excelApp.Visible = true;
    			}
    		}
    		catch(Exception ex)
    		{
    			throw new Exception("ExportToExcel: \n" + ex.Message);
    		}
    	}
    }
