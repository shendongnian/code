    void DataGridView1_RowsAdded (object sender, DataGridViewRowsAddedEventArgs e)
    {
        currentNewRow = e.RowIndex;
    }
    
    void DataGridView1_CellMouseClick(Object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.RowIndex == currentNewRow)
        {
            // don't add to Selection
        }
    } 
