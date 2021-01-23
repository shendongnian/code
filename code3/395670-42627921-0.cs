    private void dataGridInstance_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
    {
    	if (e.DesiredType == typeof(ListItem))
    	{
    		if (e.Value != null)
    		{
    			DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dataGridInstance.Rows[e.RowIndex].Cells[e.ColumnIndex];
    			foreach (object item in comboCell.Items)
    			{
    				if (item.ToString() == e.Value.ToString())
    				{
    					e.Value = item;
    					e.ParsingApplied = true;
    					return;
    				}
    			}
    		}
    	}
    }
