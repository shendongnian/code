    private void gvDocumentList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == gvDocumentList.Columns["checkbox column name"].Index && e.RowIndex >= 0)
        {
            e.PaintBackground(e.ClipBounds, true);
    
            Rectangle rectRadioButton = new Rectangle();
    
            rectRadioButton.Width = 14;
            rectRadioButton.Height = 14;
            rectRadioButton.X = e.CellBounds.X + (e.CellBounds.Width - rectRadioButton.Width) / 2;
            rectRadioButton.Y = e.CellBounds.Y + (e.CellBounds.Height - rectRadioButton.Height) / 2;
        
           e.Paint(e.ClipBounds, DataGridViewPaintParts.Focus);
    
           e.Handled = true;
       }
    }
