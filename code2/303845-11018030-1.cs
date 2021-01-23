    private int _rowMaxHeight = 0;
    private int _rowDefaultHeight = 0;
    private void dataGridView1_CellPainting(object sender, 
        DataGridViewCellPaintingEventArgs e)
    {
        if (e.Value == null || e.RowIndex < 0)
        {
            // The WordWrap code is ony executed if requested the cell has a value,
            // and if this is not the heading row.
            return;
        }
        if (e.ColumnIndex == 0)
        {
            // Resetting row max height on each row's first cell
            _rowMaxHeight = 0;
            if (_rowDefaultHeight == 0)
            {
                /* The default DataGridView row height is saved when the first cell
                 * inside the first row is populated the first time. This is later
                 * used as the minimum row height, to avoid 
                 * smaller-than-default rows. */
                _rowDefaultHeight = dataGridView1.Rows[e.RowIndex].Height;
            }
        }
        // Word wrap code
        var sOriginal = e.Graphics.MeasureString(e.Value.ToString(), 
            dataGridView1.Font);
        var sWrapped = e.Graphics.MeasureString(e.Value.ToString(), 
            dataGridView1.Font,
            // Is is MeasureString that determines the height given the width, so
            // that it properly takes the actual wrapping into account
            dataGridView1.Columns[e.ColumnIndex].Width);    
        if (sOriginal.Width != dataGridView1.Columns[e.ColumnIndex].Width)
        {
            using (Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor), 
                backColorBrush = new SolidBrush(e.CellStyle.BackColor), 
                fontBrush = new SolidBrush(e.CellStyle.ForeColor))
            {
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                // The DrawLine calls restore the missing borders: which borders
                // miss and how to paint them depends on border style settings
                e.Graphics.DrawLine(new Pen(gridBrush, 1),
                    new Point(e.CellBounds.X - 1, 
                        e.CellBounds.Y + e.CellBounds.Height - 1),
                    new Point(e.CellBounds.X + e.CellBounds.Width - 1, 
                        e.CellBounds.Y + e.CellBounds.Height - 1));
                e.Graphics.DrawLine(new Pen(gridBrush, 1),
                    new Point(e.CellBounds.X + e.CellBounds.Width - 1, 
                        e.CellBounds.Y - 1),
                    new Point(e.CellBounds.X + e.CellBounds.Width - 1, 
                        e.CellBounds.Y + e.CellBounds.Height - 1));
                //Updating the maximum cell height for wrapped text inside the row:
                // it will later be set to the row height to avoid the flickering
                // that would occur by setting the height multiple times.
                _rowMaxHeight = (Math.Ceiling(sWrapped.Height) > _rowMaxHeight)
                    ? (int)Math.Ceiling(sWrapped.Height) : _rowMaxHeight;
                // The text is generated inside the row.
                e.Graphics.DrawString(e.Value.ToString(), dataGridView1.Font, 
                    fontBrush, e.CellBounds, StringFormat.GenericDefault);
                e.Handled = true;
            }
        }
        if (e.ColumnIndex == dataGridView1.ColumnCount -1 
            && _rowMaxHeight > 0 
            && _rowMaxHeight != dataGridView1.Rows[e.RowIndex].Height)
        {
            // Setting the height only in the last cell, when the full row has been
            // painted, helps to avoid flickering when more than one row 
            // needs the wrap.
            dataGridView1.Rows[e.RowIndex].Height = 
                (_rowMaxHeight > _rowDefaultHeight) 
                ? _rowMaxHeight : _rowDefaultHeight;
        }
    }
