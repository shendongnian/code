    private void DataTable_RowChanged(object sender, DataRowChangedEventArgs e)
    {
        if ((e.Action & DataRowAction.Add) != 0) ||
            (e.Action & DataRowAction.Change) != 0))
        {
            DateTime dt = (DateTime)e.Row[DateColumn];
            if (dt != dt.Date)
                e.Row[DateColumn] = dt.Date;
        }
    }
    // Later ...
    dataTable.RowChanged += DataTable_RowChanged;
