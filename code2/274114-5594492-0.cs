    using (FileStream Xlfile = new FileStream(MyFileName, FileMode.Open, FileAccess.Read))
    {
        using (HSSFWorkbook XLBook = new HSSFWorkbook(Xlfile))
        {
    	using (NPOI.SS.UserModel.Sheet XLSheet = XLBook.GetSheetAt(0))
    	{
    	    NPOI.HSSF.UserModel.HSSFRow CurrentRow;
    	    NPOI.SS.UserModel.Cell CurrentCell;
    
    	    IEnumerator RowEnum = XLSheet.GetRowEnumerator();
    
    	    while (RowEnum.MoveNext())
    	    {
    		iLoopRows++;
    
    		if (RowEnum.Current != null)
    		{
    		    rowCounter++;
    		    CurrentRow = RowEnum.Current as NPOI.HSSF.UserModel.HSSFRow;
    
    		    for (Int32 iLoop = 0; iLoop < CurrentRow.Cells.Count; iLoop++)
    		    {
    			CurrentCell = CurrentRow.Cells[iLoop];
    
    			switch (CurrentCell.CellType)
    			{
    			    case NPOI.SS.UserModel.CellType.STRING:
    				// Reading STRING value
    				// CurrentCell.StringCellValue;
    				break;
    			    case NPOI.SS.UserModel.CellType.NUMERIC:
    				// Reading NUMERIC and DATA VALUES
    				// (CurrentCell.DateCellValue == null) ? "" : CurrentCell.DateCellValue.ToString();
    				break;
    			    default:
    				break;
    			}
    		    }
    		}
    	    }
    	}
        }
        Xlfile.Close();
    }
