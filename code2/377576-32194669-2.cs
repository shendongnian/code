    public bool DataTableToExcelFile(DataTable dt, string targetFile)
    {
    	const bool dontSave = false;
    	bool success = true;
        //Exit if there is no rows to export
    	if (dt.Rows.Count == 0) return false;
    	object misValue = System.Reflection.Missing.Value;
    	List<int> dateColIndex = new List<int>();
        Excel.Application excelApp = new Excel.Application();
    	Excel.Workbook excelWorkBook = excelApp.Workbooks.Add(misValue);
    	Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets("sheet1");
    
        //Iterate through the DataTable and populate the Excel work sheet
    	try {
    		for (int i = -1; i <= dt.Rows.Count - 1; i++) {
    			for (int j = 0; j <= dt.Columns.Count - 1; j++) {
    				if (i < 0) {
    					//Take special care with Date columns
    					if (dt.Columns(j).DataType is typeof(DateTime)) {
    						excelWorkSheet.Cells(1, j + 1).EntireColumn.NumberFormat = "d-MMM-yyyy;@";
    						dateColIndex.Add(j);
    					} 
                        //else if ... Feel free to add more Formats
                        else {
    						//Otherwise Format the column as text
    						excelWorkSheet.Cells(1, j + 1).EntireColumn.NumberFormat = "@";
    					}
    					excelWorkSheet.Cells(1, j + 1) = dt.Columns(j).Caption;
    				} 
                    else if (dateColIndex.IndexOf(j) > -1) {
    					excelWorkSheet.Cells(i + 2, j + 1) = Convert.ToDateTime(dt.Rows(i).ItemArray(j)).ToString("d-MMM-yyyy");
    				} 
                    else {
    					excelWorkSheet.Cells(i + 2, j + 1) = dt.Rows(i).ItemArray(j).ToString();
    				}
    			}
    		}
    
    		//Add Autofilters to the Excel work sheet  
     		excelWorkSheet.Cells.AutoFilter(1, Type.Missing, Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);
    		//Autofit columns for neatness
    		excelWorkSheet.Columns.AutoFit();
    		if (File.Exists(exportFile)) File.Delete(exportFile);
    		excelWorkSheet.SaveAs(exportFile);
    	} catch {
    		success = false;
    	} finally {
    		//Do this irrespective of whether there was an exception or not. 
    		excelWorkBook.Close(dontSave);
    		excelApp.Quit();
    		releaseObject(excelWorkSheet);
    		releaseObject(excelWorkBook);
    		releaseObject(excelApp);
    	}
    	return success;
    }
