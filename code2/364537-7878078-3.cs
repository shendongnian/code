    protected void gridView1_PreRender(object sender, EventArgs e)
    {
        int indexOfColumnToSpan = 0;
        int indexOfColumnToRemoveHeader = 1;
        gridView1.HeaderRow.Cells[indexOfColumnToSpan].ColumnSpan = 2;  
        gridView1.HeaderRow.Cells.RemoveAt(indexOfColumnToRemoveHeader);
    }
