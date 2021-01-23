    private DataTable GetDataGridViewAsDataTable(DataGridView _DataGridView)
    {
    try
    {
    if (_DataGridView.ColumnCount == 0) return null;
    DataTable dtSource = new DataTable();
    //////create columns
    foreach (DataGridViewColumn col in _DataGridView.Columns)
    {
    if (col.ValueType == null)
    dtSource.Columns.Add(col.Name, typeof(string));
    else
    dtSource.Columns.Add(col.Name, col.ValueType);
    dtSource.Columns[col.Name].Caption = col.HeaderText;
    }
    ///////insert row data
    foreach (DataGridViewRow row in _DataGridView.Rows)
    {
    DataRow drNewRow = dtSource.NewRow();
    foreach (DataColumn col in dtSource.Columns)
    {
    drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
    }
    dtSource.Rows.Add(drNewRow);
    }
    return dtSource;
    }
    catch { return null; }
    }
