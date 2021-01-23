         private void GetProperData()
       {
    		DataTable dtAllowedList = someclass.somefunctiontogetdata(....);
    		DataTable dtCMATM = someclass.somefunctiontogetdataTobeRemovedLaterOn(.........);
    		DataTable tblCloned = new DataTable();
    		tblCloned = dtCMATM.Clone();
    
    		foreach (DataRow dr2 in dtAllowedList.Rows)
    		{
    		DeleteRowsFromDataTable(ref tblCloned, dtCMATM, "AssignTo", dr2[0].ToString());
    		}
    				  
    		tblCloned.AcceptChanges();
    		dtCMATM = tblCloned;
    		dtCMATM.AcceptChanges();	
    	
       }
    				
    	private static void DeleteRowsFromDataTable(ref DataTable tblCloned, DataTable dtCMATM, string ColumnName, string columnValue)
    	{           
    		string strExpression = "AssignTo = '" + columnValue + "' ";
    		dtCMATM.DefaultView.RowFilter = strExpression;
    		dtCMATM = dtCMATM.DefaultView.ToTable();
    
    		if (dtCMATM.Rows.Count > 0)
    		{
    			tblCloned.ImportRow(dtCMATM.Rows[0]);
    		}           
    	}    
