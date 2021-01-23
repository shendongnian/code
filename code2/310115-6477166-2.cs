    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (!dataGridView1.Rows[e.RowIndex].IsNewRow)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "StatusImage")
            {
                if (((int)dataGridView1.Rows[e.RowIndex].Cells["ValueTwo"].Value) == 5)
                {
                    e.Value = Image.FromFile(@"C:\Pictures\TestImage1.jpg");
                }
                else
                {
                    e.Value = Image.FromFile(@"C:\Pictures\TestImage2.jpg");
                }
            }
        }
    }
