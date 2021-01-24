    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
      if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && !dataGridView1.Rows[e.RowIndex].IsNewRow) {
        string curColName = dataGridView1.Columns[e.ColumnIndex].Name;
        if (curColName.Length >= 4) {
          if (dataGridView1.Columns[e.ColumnIndex].Name.Substring(0, 4).Equals("Lap_")) {
            if (!String.IsNullOrEmpty(e.Value.ToString())) {
              e.Value = ((TimeSpan)e.Value).ToString(@"mm\:ss");
            }
          }
        }
      }
    }
