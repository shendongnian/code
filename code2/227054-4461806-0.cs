        private int selectedCellRow = 0;
        private int selectedCellColumn = 0;
        private void grid_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (e.Cell == null || e.StateChanged != DataGridViewElementStates.Selected)
                return;
            
            //if Cell that changed state is to be selected you don't need to process as event from 'unselectable' will select it again
            if (e.Cell.RowIndex == selectedCellRow && e.Cell.ColumnIndex == selectedCellColumn)
                return;
            if (e.Cell.Selected)
            {
                if (e.Cell.RowIndex == 0 || e.Cell.ColumnIndex == 0 || e.Cell.RowIndex == 1 && e.Cell.ColumnIndex == 1)
                {
                    e.Cell.Selected = false;
                    grid.Rows[selectedCellRow].Cells[selectedCellColumn].Selected = true;
                }
                else
                {
                    selectedCellRow = e.Cell.RowIndex;
                    selectedCellColumn = e.Cell.ColumnIndex;
                }
            }
            this.Text = selectedCellRow + " " + selectedCellColumn;                
        }
