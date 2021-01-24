    class MyDataGridView : DataGridView {
      protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData) {
        if ((keyData == (Keys.Enter))) {
          if (this.CurrentCell.IsInEditMode) {
            Point lastPosition = new Point(this.CurrentCell.ColumnIndex, this.CurrentCell.RowIndex);
            if (lastPosition.X == this.ColumnCount - 1) {
              lastPosition.X = 0;
              lastPosition.Y++;
            }
            else {
              lastPosition.X++;
            }
            this.CurrentCell = this.Rows[lastPosition.Y].Cells[lastPosition.X];
          }
        }
        return base.ProcessCmdKey(ref msg, keyData);
      }
    }
