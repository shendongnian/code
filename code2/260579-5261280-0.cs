    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == [your index])
        {
          //conditions and then set
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
