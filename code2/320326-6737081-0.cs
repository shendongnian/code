    // Create new DataTable.
    DataTable dt = new DataTable();
    // Total count of columns.
    int colCount = 3;
    // Add 3 columns.
    for (int i = 0; i < colCount; i++)
    {
        dt.Columns.Add(new DataColumn("col" + i.ToString()));
    }
    // Add data to the datatable.
    dt.Rows.Add(new object[] { "Empname", "Earnngs", "Amount" });
    dt.Rows.Add(new object[] { "Austin", "Earnngs", "Amount" });
    dt.Rows.Add(new object[] { "Austin", "df", "Amount" });
    dt.Rows.Add(new object[] { "sdfsdf", "dsfdf", "df" });
    dt.Rows.Add(new object[] { "Empdsfsdfname", "Earnngs", "df" });
    // Loop through each column in the DataTable and set the column name to the data in the first row of data.
    foreach (DataColumn dc in dt.Columns)
    {
        dc.ColumnName = dt.Rows[0][dc].ToString();
    }
    // Set the datasource of the grid.
    this.GridView1.DataSource = dt;
    // Bind the data to the grid.
    this.GridView1.DataBind();
