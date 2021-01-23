    int? index = null;
    int firstDisplayedRowIndex = 0;
    int sortedColumnIndex = -1;
    SortOrder sortOrder = SortOrder.Ascending;
    
    if (dgv.CurrentRow != null)
    {
        index = dgv.CurrentRow.Index;
        firstDisplayedRowIndex = dgv.FirstDisplayedScrollingRowIndex;
    
        if (dgv.SortedColumn != null)
        {
            sortedColumnIndex = dgv.SortedColumn.Index;
            sortOrder = dgv.SortOrder;
        }
    }
    
    // Repopulate grid...
    
    if (index.HasValue)
    {
        if (sortedColumnIndex > -1)
        {
            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    dgv.Sort(dgv.Columns[sortedColumnIndex], ListSortDirection.Ascending);
                    break;
                case SortOrder.Descending:
                    dgv.Sort(dgv.Columns[sortedColumnIndex],
                                            ListSortDirection.Descending);
                    break;
                    // SortOrder.None - or anthing else - do nothing
            }
        }
    
        dgv.Rows[index.Value].Selected = true;
        dgv.Rows[index.Value].Cells[0].Selected = true;
        dgv.FirstDisplayedScrollingRowIndex = firstDisplayedRowIndex;
        // Call any code that needs to know the selection might have changed
    }
