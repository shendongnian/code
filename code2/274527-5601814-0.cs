    //Process rows.
    foreach (DataRow row in dt.Rows) {
        foreach (DataColumn col in row.Table.Columns) {
            // Do whatever you need to total.
            Console.WriteLine(row[col]);
        }
    }
    // Process columns.
    foreach (DataColumn col in dt.Columns) {
        foreach (DataRow row in col.Table.Rows) {
            // Do whatever you need to total.
            Console.WriteLine(row[col]);
        }
    }
