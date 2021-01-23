            private static DataTable CreateUpdateDataTableForRowAdd(DataSet originalDataSet, int originalDataTableIndex, DataRow addedDataRow)
        {
            DataSet updateDataSet = originalDataSet.Clone();
            DataTable updateDataTable = updateDataSet.Tables[originalDataTableIndex];
            DataRow dataRow = updateDataTable.NewRow();
            int columnCount = updateDataTable.Columns.Count;
            for (int i = 0; i < columnCount; ++i)
            {
                dataRow[i] = addedDataRow[i, DataRowVersion.Proposed];
            }
            updateDataTable.Rows.Add(dataRow);
            // dataRow state is *Added*
            return updateDataTable;
        }
        private static DataTable CreateUpdateDataTableForRowChange(DataSet originalDataSet, int originalDataTableIndex, DataRow changedDataRow)
        {
            DataSet updateDataSet = originalDataSet.Clone();
            DataTable updateDataTable = updateDataSet.Tables[originalDataTableIndex];
            DataRow dataRow = updateDataTable.NewRow();
            int columnCount = updateDataTable.Columns.Count;
            for (int i = 0; i < columnCount; ++i)
            {
                dataRow[i] = changedDataRow[i, DataRowVersion.Original];
            }
            updateDataTable.Rows.Add(dataRow);
            dataRow.AcceptChanges();
            dataRow.BeginEdit();
            for (int i = 0; i < columnCount; ++i)
            {
                dataRow[i] = changedDataRow[i, DataRowVersion.Proposed];
            }
            dataRow.EndEdit();
            // dataRow state is *Modified*
            return updateDataTable;
        }
        private static DataTable CreateUpdateDataTableForRowDelete(DataSet originalDataSet, int originalDataTableIndex, DataRow deletedDataRow)
        {
            DataSet updateDataSet = originalDataSet.Clone();
            DataTable updateDataTable = updateDataSet.Tables[originalDataTableIndex];
            DataRow dataRow = updateDataTable.NewRow();
            int columnCount = updateDataTable.Columns.Count;
            for (int i = 0; i < columnCount; ++i)
            {
                dataRow[i] = deletedDataRow[i, DataRowVersion.Original];
            }
            updateDataTable.Rows.Add(dataRow);
            dataRow.AcceptChanges();
            dataRow.Delete();
            // dataRow state is *Deleted*
            return updateDataTable;
        }
