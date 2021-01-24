    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if ( e.RowIndex >= 0 && e.ColumnIndex == 0)
        {
            Brush br = e.State.HasFlag(DataGridViewElementStates.Selected) ?
                SystemBrushes.HighlightText : SystemBrushes.WindowText;
            Font font = dataGridView1.DefaultCellStyle.Font;
            Rectangle r2 = new Rectangle(e.CellBounds.X + 24, e.CellBounds.Y, 
                e.CellBounds.Width - 24, e.CellBounds.Height);
            e.PaintBackground(e.CellBounds, true);
            using (StringFormat fmt = new StringFormat()
            { LineAlignment = StringAlignment.Center})
               if (e.Value != null) e.Graphics.DrawString(e.Value.ToString(), font, br, r2, fmt);
            e.PaintContent(e.CellBounds);
            e.Handled = true;
        }
    }
