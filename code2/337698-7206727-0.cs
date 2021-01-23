    private void dataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        // use whatever your row data type is here
        MyDataType item = (MyDataType)(dataGrid.Rows[e.RowIndex].DataBoundItem);
        // only highlight children
        if (item.parentID != 0)
        {
            // calculate the bounds of the row
            Rectangle rowBounds = new Rectangle(
                dataGrid.RowHeadersVisible ? dataGrid.RowHeadersWidth : 0, // left
                e.RowBounds.Top, // top
                dataGrid.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - dataGrid.HorizontalScrollingOffset + 1, // width 
                e.RowBounds.Height // height
            ); 
            // if the row is selected, use default highlight color
            if (dataGrid.Rows[e.RowIndex].Selected)
            {
                using (Brush brush = new SolidBrush(dataGrid.DefaultCellStyle.SelectionBackColor))
                    e.Graphics.FillRectangle(brush, rowBounds);
            }
            else // otherwise use a special color
                e.Graphics.FillRectangle(Brushes.PowderBlue, rowBounds);
  
            // prevent background from being painted by Paint method
            e.PaintParts &= ~DataGridViewPaintParts.Background;     
        }   
    }
