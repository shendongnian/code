    DataGridViewCell cell_Changed = null;
	DataGridViewCell cell_Begin = null;
	string cell_Begin_Save = "";
	bool cell_Reset = false;
    private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
    	int colIndex = e.ColumnIndex;
    	int rowIndex = e.RowIndex;
    
    	if (e.RowIndex >= 0)
    	{
    		cell_Changed = DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
    	}
    
    	if (cell_Changed != null)
    	{
    		if (cell_Begin_Save != cell_Changed.Value.ToString())
    		{
    			DataGridView1.Rows[rowIndex].Cells[colIndex].Style.BackColor = Color.Green;
    			cell_Reset = false;
            }
        }
    }
    private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
	{
		int colIndex = e.ColumnIndex;
		int rowIndex = e.RowIndex;
		if (e.RowIndex >= 0 && !cell_Reset)
		{
			cell_Begin = DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
			cell_Begin_Save = cell_Begin.Value.ToString();
			cell_Reset = true;
		}
	}
	private void DataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
	{
		cell_Reset = false;
	}
