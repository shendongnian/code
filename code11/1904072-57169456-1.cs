    private void DataGridView1_CellPainting(object sender, 
        DataGridViewCellPaintingEventArgs e)
    {
        var cellBounds = e.CellBounds;
        // Left part of cell
        cellBounds.Width = cellBounds.Width / 2;
        e.CellStyle.BackColor = Color.Black;
        e.CellStyle.ForeColor = Color.White;
        e.Graphics.SetClip(cellBounds);
        e.PaintBackground(e.ClipBounds, true);
        // draw all parts except background
        e.Paint(e.CellBounds, 
            DataGridViewPaintParts.All & (~DataGridViewPaintParts.Background));
        // Right part of cell
        cellBounds.X = cellBounds.Right;
        e.CellStyle.BackColor = Color.White;
        e.CellStyle.ForeColor = Color.Black;
        e.Graphics.SetClip(cellBounds);
        e.PaintBackground(e.ClipBounds, true);
        // draw all parts except background
        e.Paint(e.CellBounds, 
            DataGridViewPaintParts.All & (~DataGridViewPaintParts.Background));
        e.Handled = true;
    }
