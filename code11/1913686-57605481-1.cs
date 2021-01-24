    private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == 1 && 
           (e.Value == DBNull.Value || e.Value == null))
        {
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All &
                ~DataGridViewPaintParts.ContentForeground);
            e.Handled = true;
        }
    }
