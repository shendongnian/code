    private void dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (e.ColumnIndex == theColumnToValidate.Index)
        {
            decimal d;
            if (!decimal.TryParse(e.FormattedValue.ToString(), out d))
            {
                MessageBox.Show("Please enter a decimal number");
                e.Cancel = true;
            }
        }
    }
