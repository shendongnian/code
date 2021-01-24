     k=0;
     for (int i = 0; i < dgv.Rows.Count; i++)
     {
    	 addRow=true;
         for (int j = 0; j < dgv.ColumnCount; j++)
         {
            if (dgv.Rows[i].Cells[j].Selected == true)
            {
    			if(addRow){
    				dt.Rows.Add();
    				addRow=false;
    				k++;
    			}
    			dt.Rows[k][j] = dgv.Rows[i].Cells[j].Value;
            }
         }
      }
       dt.AcceptChanges();
