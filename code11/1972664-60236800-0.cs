    using (var ew = new ExcelWriter("C:\\temp\\test.xlsx"))
    {
        int col = 1;
        int row = 1;
        foreach (DataColumn col in dta.Columns)
        {
            ew.Write(col.ColumnName, col++, row);
        }
        foreach (DataRow dr in dta.Rows)
        {
            ++row;
            for (col = 1; col <= dta.Columns.Count; col++)
            {
                ew.Write(dr[col-1].ToString(), col, row);
            }
        }
    }
