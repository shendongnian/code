    private void dataView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        foreach (DataGridViewRow row in dataView.Rows)
        {
            int value = Convert.ToInt32(row.Cells[2].Value);
            if (value == 1)
            {
                row.DefaultCellStyle.BackColor = Color.Orange;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
