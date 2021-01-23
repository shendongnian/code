    foreach (DataRow row in dt1.Rows)
    {
        if (row.RowState == DataRowState.Modified)
        {
            bool isUnchanged = true;
            foreach (DataColumn col in dt1.Columns)
            {
                if (!row[col.ColumnName].Equals(row[col.ColumnName, DataRowVersion.Original]))
                {
                    isUnchanged = false;
                    break;
                }
            }
    
            if (isUnchanged)
            {
                row.RejectChanges();
            }
        }
    }
