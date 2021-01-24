    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        //mering all cells in a first row
        if (e.RowIndex == 0)
        {
            if (e.ColumnIndex == 0)
            {
                e.PaintBackground(e.ClipBounds, true);
                Rectangle r = e.CellBounds;
                for (int i = 1; i < (sender as DataGridView).ColumnCount; i++)
                    r.Width += (sender as DataGridView).GetCellDisplayRectangle(i, 0, true).Width;
                r.Width -= 1;
                r.Height -= 1;
                using (SolidBrush brBk = new SolidBrush(e.CellStyle.BackColor))
                using (SolidBrush brFr = new SolidBrush(e.CellStyle.ForeColor))
                {
                    e.Graphics.FillRectangle(brBk, r);
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, brFr, r, sf);
                }
    
                e.Handled = true;
           }
           else
                if (e.ColumnIndex > 0)
                {
                   using (Pen p = new Pen((sender as DataGridView).GridColor))
                        {
                        //bottom line of a cell 
                        e.Graphics.DrawLine(p, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                        //right vertical line of a last cell in a row
                        if (e.ColumnIndex == (sender as DataGridView).ColumnCount - 1)
                        e.Graphics.DrawLine(p, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    }
    
                    e.Handled = true;
                }
            }
    }
    
    
    private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
    {
            //force redraw first row when scrolling
            for (int i = 0; i < (sender as DataGridView).ColumnCount; i++)
                (sender as DataGridView).InvalidateCell(i, 0);
    }
