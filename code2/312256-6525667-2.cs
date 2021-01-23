    foreach (DataRow row in dt1.Rows)
    {
        if (row.RowState == DataRowState.Modified)
        {
            var original = dt1.Columns.Cast<DataColumn>()
                              .Select(c => row[c, DataRowVersion.Original]);
                              
            bool isUnchanged = row.ItemArray.SequenceEqual(original);
            if (isUnchanged)
            {
                row.RejectChanges();
            }
        }
    }
