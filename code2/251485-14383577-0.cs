    <pre><code>private void RTLColumnsDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
       {
          if (e.ColumnIndex == RTLColumnID && e.RowIndex >= 0)
          {
             e.PaintBackground(e.CellBounds, true);
              TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString(),
              e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor,
               TextFormatFlags.RightToLeft | TextFormatFlags.Right);
              e.Handled = true;
           }
       }</code></pre>
