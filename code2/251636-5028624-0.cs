    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
         if (e.Value != null)
         {
             if (condition)
                e.CellStyle.BackColor = Color.FromArgb(255, 160, 160);
         }               
    }
