    public bool IsExcelOpened()
    		{
    			bool isOpened = false;
    
    			try
    			{
    				Excel.Application exApp;
    				Excel.Worksheet xlWorksheet;
    				exApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application") as Excel.Application;
    				if(exApp != null)
    				{
    					xlWorksheet = (Excel.Worksheet)exApp.ActiveSheet;
    					isOpened = true;
    				}
    			}
    			catch { }
    			return isOpened;
    		}
