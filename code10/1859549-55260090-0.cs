    private static int GetRowExcel(string projectName)
    	{
    		using (MemoryStream stream = new MemoryStream(bin))
    		using (ExcelPackage excelPackage = new ExcelPackage(stream))
    		{
    			var ws = excelPackage.Workbook.Worksheets["Work"];
    
    			string nrNummer = projectName.Split(' ').First();
    			for (int row = 5; ws.Cells[row, 5].Value != null; row++)
    			{
    			   if(ws.Cells[row, 5].Value.ToString()==nrNummer)
    				{ 
    					return row;
    				}
    				
    			}
    		}
    		return -1;  // return any value that shows that row is not found
    	}
