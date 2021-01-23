	void OnLoad()
	{
		base.OnLoad(e);
		...
		_dataTable.TableNewRow += HandleTableNewRow;
	}
	void HandleTableNewRow(object sender, DataTableNewRowEventArgs e)
	{
		SetAutoIncrementValues(e.Row);
	}
	void SetAutoIncrementValues(DataRow row)
	{
		foreach (DataColumn dataColumn in _dataTable.Columns
			.OfType<DataColumn>()
			.Where(column => column.AutoIncrement))
		{
			using (SqlCeCommand sqlcmd = new SqlCeCommand(
				"SELECT AUTOINC_NEXT FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" +
				Name + "' AND COLUMN_NAME = '" + dataColumn.ColumnName + "'", _connection))
			using (SqlCeResultSet queryResult =
				sqlcmd.ExecuteResultSet(ResultSetOptions.Scrollable))
			{
				if (queryResult.ReadFirst())
				{
					var nextValue = Convert.ChangeType(queryResult.GetValue(0), dataColumn.DataType);
					if (!nextValue.Equals(row[dataColumn.Ordinal]))
					{
						// Since an auto-increment column is going to be read-only, apply
						// the new auto-increment value via a separate array variable.
						object[] rowData = row.ItemArray;
						rowData[dataColumn.Ordinal] = nextValue;
						row.ItemArray = rowData;
					}
				}
			}
		}
	}
