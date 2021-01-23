    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      var dataGridView = sender as DataGridView;
      if (dataGridView.Rows[e.RowIndex].Selected)
      {
        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
        // edit: to change the background color:
        e.CellStyle.SelectionBackColor = Color.Coral;
      }
    }
