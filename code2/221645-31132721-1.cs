    private void gvItReq_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        for (int colIdx = 0; colIdx < gvItReq.Columns.Count; colIdx++)
            gvItReq.Columns[colIdx].SortMode = DataGridViewColumnSortMode.NotSortable;
    }
