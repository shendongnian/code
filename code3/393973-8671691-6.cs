    private void AttachDataTableEvents()
    {
        _dataTable.RowChanging += new DataRowChangeEventHandler(DataTable_RowChanging);
        _dataTable.RowChanged += new DataRowChangeEventHandler(DataTable_RowChanged);
        _dataTable.RowDeleting += new DataRowChangeEventHandler(DataTable_RowDeleting);
        _dataTable.RowDeleted += new DataRowChangeEventHandler(DataTable_RowDeleted);
    }
    private void DataTable_RowChanging(object sender, DataRowChangeEventArgs e)
    {
        Trace.WriteLine(string.Format("DataTable_RowChanging(): Action {0}, RowState {1}", e.Action, e.Row.RowState));
        if (e.Action == DataRowAction.Add)
        {
            e.Row.ClearErrors();
            DataTable updateDataTable = CreateUpdateDataTableForRowAdd(_dataSet, 0, e.Row);
            int rowsAffected;
            string errorMessage;
            if (!UpdateTableData(updateDataTable, out rowsAffected, out errorMessage))
            {
                e.Row.RowError = errorMessage;
                throw new ArgumentException(errorMessage);
            }
        }
        else if (e.Action == DataRowAction.Change)
        {
            e.Row.ClearErrors();
            DataTable updateDataTable = CreateUpdateDataTableForRowChange(_dataSet, 0, e.Row);
            int rowsAffected;
            string errorMessage;
            if (!UpdateTableData(updateDataTable, out rowsAffected, out errorMessage))
            {
                e.Row.RowError = errorMessage;
                throw new ArgumentException(errorMessage);
            }
        }
    }
    private void DataTable_RowChanged(object sender, DataRowChangeEventArgs e)
    {
        Trace.WriteLine(string.Format("DataTable_RowChanged(): Action {0}, RowState {1}", e.Action, e.Row.RowState));
        if (e.Action == DataRowAction.Add)
        {
            e.Row.AcceptChanges();
        }
        else if (e.Action == DataRowAction.Change)
        {
            e.Row.AcceptChanges();
        }
    }
    private void DataTable_RowDeleting(object sender, DataRowChangeEventArgs e)
    {
        Trace.WriteLine(string.Format("DataTable_RowDeleting(): Action {0}, RowState {1}", e.Action, e.Row.RowState));
        // can't stop the operation here
    }
    private void DataTable_RowDeleted(object sender, DataRowChangeEventArgs e)
    {
        Trace.WriteLine(string.Format("DataTable_RowDeleted(): Action {0}, RowState {1}", e.Action, e.Row.RowState));
        DataTable updateDataTable = CreateUpdateDataTableForRowDelete(_dataSet, 0, e.Row);
        int rowsAffected;
        string errorMessage;
        if (!UpdateTableData(updateDataTable, out rowsAffected, out errorMessage))
        {
            e.Row.RejectChanges();
            Mediator mediator = _iUnityContainer.Resolve<Mediator>();
            mediator.NotifyColleagues<string>(MediatorMessages.NotifyViaModalDialog, errorMessage);
        }
        else
        {
            e.Row.AcceptChanges();
        }
    }
