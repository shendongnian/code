    private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
    {
    	// If this is column 1
    	if (e.ColumnIndex == 1)
    	{
    		// Remove special chars from cell value
    		e.Value = RemoveSpecialCharacters(e.Value.ToString());
    		e.ParsingApplied = true;
    	}
    }
