    foreach (Telerik.WinControls.UI.GridViewRowInfo rowInfo in reportGridView.Rows)
    {
        foreach (Telerik.WinControls.UI.GridViewCellInfo cell in rowInfo.Cells)
        {
            if (cell.ColumnInfo.GetType() == typeof(Telerik.WinControls.UI.GridViewCheckBoxColumn))
            {
                if (cell.Value != null && (bool)cell.Value == true)
                {
                    // Some logic here to handle this ...
                }
            }
        }
    }
