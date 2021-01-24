    private void Add_DGV_To_Doc(DataGridView dgv, Word.Document doc) {
      object mis = System.Reflection.Missing.Value;
      object endOfDoc = "\\endofdoc";
      Word.Range range = doc.Bookmarks.get_Item(ref endOfDoc).Range;
      Word.Table table = doc.Tables.Add(range, dgv.RowCount + 1, dgv.ColumnCount, ref mis, ref mis);
      object prarRange = doc.Bookmarks.get_Item(ref endOfDoc).Range;
      Word.Paragraph para = doc.Content.Paragraphs.Add(ref prarRange);
      para.Range.Text = Environment.NewLine;
      string value;
      for (int col = 0; col < dgv.ColumnCount; col++) {
        table.Cell(1, col + 1).Range.Text = dgv.Columns[col].HeaderText;
      }
      int tableRow = 2;
      for (int row = 0; row < dgv.RowCount; row++) {
        if (!dgv.Rows[row].IsNewRow) {
          for (int col = 0; col < dgv.ColumnCount; col++) {
            value = "";
            if (dgv.Rows[row].Cells[col].Value != null) {
              value = dgv.Rows[row].Cells[col].Value.ToString();
            }
            table.Cell(tableRow, col + 1).Range.Text = value;
          }
          tableRow++;
        }
      }
      FormatTable(table);
    }
