    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)//remove padding
    {
       // ignore the column header and row header cells
    
       if (e.RowIndex != -1 && e.ColumnIndex != -1)
       {
          e.PaintBackground(e.ClipBounds, true);
          e.Graphics.DrawString(Convert.ToString(e.FormattedValue), e.CellStyle.Font, Brushes.Gray, e.CellBounds.X, e.CellBounds.Y - 2, StringFormat.GenericDefault)
          e.Handled = true;
       }
    }
