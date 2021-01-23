    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        //check only for cells of second column, except header
    	if ((e.ColumnIndex == 1) && (e.RowIndex > -1))
    	{
            //make sure not a null value
    		if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != DBNull.Value)
    		{
                //put condition when not to paint checkbox
    			if (Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value) > 2)
    			{
    				e.Paint(e.ClipBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.Background);  //put what to draw
    				e.Handled = true;   //skip rest of painting event
    			}
    		}
    	}
    }
