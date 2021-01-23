    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == [your index])
        {
          //conditions and then set like e,RowIndex % 2 == 0
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
