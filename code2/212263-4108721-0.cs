    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
        e.Paint(e.ClipBounds, e.PaintParts);
        if ((e.RowIndex == myRowIndex) && (e.ColumnIndex == myColumnIndex)) {
            Pen pen = new Pen(Color.Red, 2f);
            e.Graphics.DrawRectangle(pen, e.CellBounds);
        }
        e.Handled = true;
    }
