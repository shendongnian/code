    private void SalesGridView_SelectionChanged(object sender, EventArgs e)
    {
        float sumNumbers = 0;
        for (int i = 0; i < SalesGridView.SelectedCells.Count; i++)
        {
            var selectedCell = SalesGridView.SelectedCells[i];
            if (selectedCell.ColumnIndex = SalesGridView.Columns["TotalBillColumn"].Index)
            {
                float nextNumber = 0;
    
                if (float.TryParse(selectedCell.FormattedValue.ToString(), out nextNumber))
                    sumNumbers += nextNumber;
            }
        }
    
        label1.Text = "selected value " + sumNumbers;
        label2.Text = "nr selected cells " + SalesGridView.SelectedCells.Count.ToString();
    }
