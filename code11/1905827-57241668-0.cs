    private void DataGridView1_CellPainting(object sender, 
        DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex == -1)
        {
            e.Paint(e.ClipBounds, e.PaintParts);
            using (var pen = new Pen(Color.Red, 10))
                e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom,
                    e.CellBounds.Right, e.CellBounds.Bottom);
            e.Handled = true;
        }
    }
