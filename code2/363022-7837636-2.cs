    private void CustomersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex.ToString() == "9")
        {
            DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)CustomersDataGridView.Rows[e.RowIndex].Cells[9];
            DataGridViewRow row = CustomersDataGridView.Rows[e.RowIndex] as DataGridViewRow;
            if (Convert.ToBoolean(checkCell.EditedFormattedValue) && CustomersDataGridView.IsCurrentCellDirty)
            {
                //Do Work here.
                var z = row.Cells[0].Value; // Fill in the brackets with the column you want to fetch values from
                //z in this case would be the value of whatever was in the first cell in the row of the checkbox I clicked
            }
        }
    }
