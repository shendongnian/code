    DataGridView.DataGridViewDataConnection dataConnection = dataGridView.DataConnection;
    if (dataConnection == null)
    {
        return null;
    }
    if (dataConnection.CurrencyManager.Count <= rowIndex)
    {
        return this.Properties.GetObject(PropCellValue);
    }
    return dataConnection.GetValue(this.OwningColumn.BoundColumnIndex, this.ColumnIndex, rowIndex);
