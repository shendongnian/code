    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        var cell = dataGridView1[e.ColumnIndex, e.RowIndex];
        if (cell.Value.Equals("alfarithmitiko"))
        {
            MyHiddenText.Visible = true;
        }
    }
