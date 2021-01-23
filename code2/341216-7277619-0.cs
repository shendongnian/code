    private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e) {
        if (e.Column.Index == 1) {  // This is your custom data's column.
            // Extract the numeric values from the cells being compared for the sort.
            // BEWARE: code assumes you'll always be able to extract a long from the cell contents.
            long cell1NumericValue = Int64.Parse(e.CellValue1.ToString().Split(' ')[0]);
            long cell2NumericValue = Int64.Parse(e.CellValue2.ToString().Split(' ')[0]);
            
            // Compare these numeric values to determine how to sort.
            e.SortResult = cell1NumericValue.CompareTo(cell2NumericValue);
    
            e.Handled = true;
        }
    }
