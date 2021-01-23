    DataRow totalsRow = dt.NewRow();
    foreach (DataColumn col in dt.Columns) {
        int colTotal = 0;
        foreach (DataRow row in col.Table.Rows) {
            colTotal += Int32.Parse(row[col].ToString());
        }
        totalsRow[col.ColumnName] = colTotal;
    }
    dt.Rows.Add(totalsRow);
