    private void WriteGridToCSV(DataGridView dgv, string filename) {
      StreamWriter sw = new StreamWriter(filename);
      // write headers - we do not want to write the balance column
      for (int col = 0; col < dgv.Columns.Count - 1; col++) {
        sw.Write(dgv.Columns[col].HeaderText);
        if (col < dgv.Columns.Count - 2) {
          sw.Write("\t");
        }
      }
      sw.WriteLine();
      // Write data - we do not want to save the balance column
      for (int row = 0; row < dgv.RowCount; row++) {
        for (int col = 0; col < dgv.ColumnCount - 1; col++) {
          if (!dgv.Rows[row].IsNewRow) {
            sw.Write(dgv.Rows[row].Cells[col].Value);
            if (col < dgv.ColumnCount - 2) {
              sw.Write("\t");
            }
          }
        }
        sw.WriteLine();
      }
      sw.Close();
      MessageBox.Show("Write finished");
    }
 
