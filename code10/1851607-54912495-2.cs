    DataSet ds1 = <<fetch dataset1>>;
    DataSet ds2 = <<fetch dataset2>>;
    // Loop through all of the tables in the 1st DataSet
    foreach (DataTable tbl1 in ds1.Tables)
    {
        // If the 2nd DataSet has a table with same name as the one from the 1st DataSet
        if (ds2.Tables.Contains(tbl1.TableName))
        {
            DataTable tbl2 = ds2.Tables[tbl1.TableName];
            // Create a list of column names that the two tables have in common.
            // We will only compare the values in these two tables, in this set of matching column names.
            List<string> commonColumnNames = new List<string>(tbl1.Columns.Cast<DataColumn>().Select(c => c.ColumnName).Intersect(tbl2.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
            // Before we start comparing the rows in the two tables, find out which one has the fewer number of rows in it.
            int maxRows = Math.Min(tbl1.Rows.Count, tbl2.Rows.Count);
            // If the tables have a different number of rows, then we will only compare the set of rows numbered 0-to-MinRowCount
            for (int r = 0; r <= maxRows; r++)
            {
                // For each row, compare the values of common columns
                foreach (string colName in commonColumnNames)
                {
                   if (tbl1.Rows[r][colName] != tbl2.Rows[r][colName])
                   {
                        // Different value
                   }
                }
            }
        }
    }
