    public void GetVisibleCells(DataGridView dgv)
        {
            var visibleRowsCount = dgv.DisplayedRowCount(true);
            var firstDisplayedRowIndex = dgv.FirstDisplayedCell.RowIndex;
            var lastvisibleRowIndex = (firstDisplayedRowIndex + visibleRowsCount) - 1;
            for (int rowIndex = firstDisplayedRowIndex; rowIndex <= lastvisibleRowIndex; rowIndex++)
            {
                var cells = dgv.Rows[rowIndex].Cells;
                foreach (DataGridViewCell cell in cells)
                {
                    if (cell.Displayed)
                    {
                        // This cell is visible...
                        // Your code goes here...
                    }
                }
            }
        }
