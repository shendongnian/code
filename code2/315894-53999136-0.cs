    void SomeMethod()
    {
        DataGridView dgv = ...;
        
        // Iterate through the rows, building the dictionary.
        Dictionary<DataGridViewRow, int> rowToRowNumber = ...;
        int iFirstSelected = -1;
        for (int iRow = 0; iRow < dgv.Rows.Count; iRow++)
        {
            DataGridViewRow row = dgv.Rows[iRow];
            
            int iAdjusted = iRow;
            if (row.Selected)
            {
                if (iFirstSelected < 0)
                    iFirstSelected = iRow;
                iAdjusted = iFirstSelected;
            }
            rowToRowNumber[row] = iAdjusted;
        }
        
        // Sort.
        dgv.Sort(new RowComparer(rowToRowNumber));
    }
    
    
    private class RowComparer : System.Collections.IComparer
    {
        // Values are the row numbers before the sort was done,
        // with all rows to sort set to the same value (the row number of the first row to sort).
        Dictionary<DataGridViewRow, int> _rowToRowNumber;
        public RowComparer(Dictionary<DataGridViewRow, int> rowToRowNumber)
        {
            _rowToRowNumber = rowToRowNumber;
        }
        public int Compare(object x, object y)
        {
            DataGridViewRow row1 = (DataGridViewRow)x;
            DataGridViewRow row2 = (DataGridViewRow)y;
            // Keep rows in order.
            int result = _rowToRowNumber(row1).CompareTo(_rowToRowNumber(row2));
            if (result != 0)
                return result;
            // Same row number, these are the rows to sort.
            return CustomCompare(row1, row2);
        }
        
        private int CustomCompare(DataGridViewRow row1, DataGridViewRow row2)
        {
            // Replace with your custom logic.
            // TODO: If cells contain strings, may have to parse them into the
            // original data types, and compare those typed values rather than the cell values themselves.
            return row1.Cells[1].Value.CompareTo(row2.Cells[1].Value);
        }
    }
