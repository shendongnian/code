    DataTable dt = new DataTable();
    dt.Columns.Add("name", typeof(string));
    dt.Columns.Add("dayofbirth", typeof(DateTime));
    // Fill your data table
    ...
    // Bind your data table against the grid view.    
    dataGridView1.DataSource = dt;
    // Set format styles for your date columns (after binding)
    CultureInfo ci = CultureInfo.CreateSpecificCulture("en-US");
    dataGridView1.Columns[1].DefaultCellStyle.FormatProvider = ci;
    dataGridView1.Columns[1].DefaultCellStyle.Format = ci.DateTimeFormat.LongDatePattern;
