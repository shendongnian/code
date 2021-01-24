    DataSet ds1 = <<fetch dataset1>>;
    DataSet ds2 = <<fetch dataset2>>;
    foreach (DataTable tbl1 in ds1.Tables)
    {
        if (ds2.Tables.Contains(tbl1.TableName))
        {
            DataTable tbl2 = ds2.Tables[tbl1.TableName];
            List<string> commonColumnNames = new List<string>(tbl1.Columns.Cast<DataColumn>().Select(c => c.ColumnName).Intersect(tbl2.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
            int maxRows = Math.Min(tbl1.Rows.Count, tbl2.Rows.Count);
            for (int r = 0; r <= maxRows; r++)
            {
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
