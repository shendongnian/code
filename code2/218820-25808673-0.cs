    private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
         if(e.RowIndex>=0 && e.ColumnIndex == indexOfButtonColumn  && value[e.RowIndex] != "bob")
         {
               e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground & ~DataGridViewPaintParts.ContentBackground); 
               e.Handled = true;      
         }
    }
