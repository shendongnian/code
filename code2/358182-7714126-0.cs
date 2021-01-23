    void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
        {
            dataGridView1.Rows[e.RowIndex].ErrorText =
                "Company Name must not be empty";
            e.Cancel = true;
        }
        else
        {
            dataGridView1.Rows[e.RowIndex].ErrorText = string.Empty;
        }
    }
