    private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 1)
        {
            string selected = dataGridView3[1, e.RowIndex].FormattedValue.ToString();
            if (selected.Length > 50)
            {
                dataGridView1[3, e.RowIndex].Value = selected.Substring(0, 50);
            }
        }
    }
