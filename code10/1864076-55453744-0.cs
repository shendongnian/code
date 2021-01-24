    private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == 0)
        {         
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index == e.RowIndex)
                {
                    row.Cells["checkBoxColumn"].Value = 
                    !Convert.ToBoolean(row.Cells["checkBoxColumn"].EditedFormattedValue);
                }
                else
                {
                    row.Cells["checkBoxColumn"].Value = false;
                }
            }
        }
    }
