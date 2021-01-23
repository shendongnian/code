    // Sum rows.
    foreach (DataRow row in dt.Rows) {
        int rowTotal = 0;
        foreach (DataColumn col in row.Table.Columns) {
            Console.WriteLine(row[col]);
            rowTotal += Int32.Parse(row[col].ToString());
        }
        Console.WriteLine("row total: {0}", rowTotal);
    }
    // Sum columns.
    foreach (DataColumn col in dt.Columns) {
        int colTotal = 0;
        foreach (DataRow row in col.Table.Rows) {
            Console.WriteLine(row[col]);
            colTotal += Int32.Parse(row[col].ToString());
        }
        Console.WriteLine("column total: {0}", colTotal);
    }
