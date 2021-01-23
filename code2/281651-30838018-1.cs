    private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
        // Vertical text from column 0, or adjust below, if first column(s) to be skipped
        if (e.RowIndex == -1 && e.ColumnIndex >= 0) {
            e.PaintBackground(e.CellBounds, true);
            e.Graphics.TranslateTransform(e.CellBounds.Left , e.CellBounds.Bottom);
            e.Graphics.RotateTransform(270);
            e.Graphics.DrawString(e.FormattedValue.ToString(),e.CellStyle.Font,Brushes.Black,5,5);
            e.Graphics.ResetTransform();
            e.Handled = true;
        }
    }
