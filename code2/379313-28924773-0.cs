    if (!GridView1.Rows[GridView1.CurrentCell.RowIndex].IsNewRow)
    {
    	 foreach (DataGridViewCell cell in GridView1.Rows[GridView1.CurrentCell.RowIndex].Cells)
    	{
    		//here you must test for all and then return only if it is false
    		if (cell.Value == System.DBNull.Value)
    		{
    			return false;
    		}
    	}
    }
