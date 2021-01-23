    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 3 && e.RowIndex == 5)
        {
            MyHiddenText.Visible = true;
        }
    }
