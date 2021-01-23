    private void grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
      if (e.Button == System.Windows.Forms.MouseButtons.Right) {
        contextMenuHeader.Show(Cursor.Position);
      }
    }
