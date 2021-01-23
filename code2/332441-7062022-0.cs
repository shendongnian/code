    private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // if NOT the DataGridView's new row
        if (!this.dataGridView1.Rows[e.RowIndex].IsNewRow)
        {
            // if my desired column
            if (e.ColumnIndex == 0)
            {
                TestDataSet.TestRow row;
                row = (TestDataSet.TestRow)((DataRowView)this.dataGridView1.Rows[e.RowIndex].DataBoundItem).Row;
                if (row.Column1, (int)row["Column1", DataRowVersion.Original]) > 0)
                        e.CellStyle.ForeColor = Color.Red;
            }
        }
    }
