       private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (RowShouldBeRed(e))
            {
                e.CellStyle.BackColor = Color.LightPink;
                e.CellStyle.SelectionBackColor = Color.Red;
            }
            else
            {
                e.CellStyle.BackColor = DataGridView1.DefaultCellStyle.BackColor;
                e.CellStyle.SelectionBackColor = DataGridView1.DefaultCellStyle.SelectionBackColor;
            }
        }
     
