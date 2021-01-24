    private void gridView1_RowStyle(object sender, RowStyleEventArgs e)  {  
    
        If (e.RowHandle = this.gridView1.FocusedRowHandle)  
    	{
    	   string strBS = gridView1.GetRowCellValue(row, "BS");
    	   string strRepere = gridView1.GetRowCellValue(row, "Repère");
    	    if (SearchRow(strBS,strRepere)==true)
    	     {
    		   e.Appearance.BackColor = Color.Red  
    		   e.HighPriority = True  
    	      }
    	}
    }
    
    private bool SearchRow(string strBS, string strRepere)  {  
        bool RowExist=false;
        for (int j = 0; j < gridView3.RowCount; j++)
        {
    	  if (gridView3.GetRowCellValue(j, "ProjectN").ToString() ==strBS &&
    	    gridView3.GetRowCellValue(j, "Parts").ToString()==strRepere)
    	  {
    	     RowExist=true;
    	     Break;
    	  }
        }
       return RowExist;    
    }
