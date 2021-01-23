    private DataGridViewCell _lastCellSelected = null;
    private void dataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if(dataGridView.SelectedCells.Count == 0)
        {
            _lastCellSelected = null;
            return;
        }
        
        DataGridViewCell selectedCell = dataGridView.SelectedCells[0];
        if(_lastCellSelected == null || selectedCell.ColumnIndex == _lastCellSelected.ColumnIndex)
        {
            //User clicked first cell
            _lastCellSelected = selectedCell;
        }
        else
        {
            //User has clicked two cells from different columns
            string filename1 = _lastCellSelected.Value;
            string filename2 = selectedCell.Value;
            
            //TODO: "Merge" files here
            
            _lastCellSelected = null;
        }
    }
