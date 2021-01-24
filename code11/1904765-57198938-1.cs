    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("Col1"));
    dt.Columns.Add(new DataColumn("Col2"));
    dt.Columns.Add(new DataColumn("Col3"));
    writeColumns(dt, @"c:\yourdirectory\table.csv");
