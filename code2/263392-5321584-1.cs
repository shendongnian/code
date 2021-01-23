    private void AddRow(DataTable dt, params string[] names)
    {
        // Expand columns as required
        while (dt.Columns.Count < names.Length)
        {
            DataColumn col = dt.Columns.Add();
            col.ColumnName = dt.Columns.Count.ToString();
        }
        // Add new row
        DataRow row = dt.NewRow();
        for (int i = 0; i < names.Length; i++)
            row[i] = names[i];
        dt.Rows.Add(row);
    }
    private void AddToColumn(DataTable dt, int rowIdx, int colIdx, string name)
    {
        while (dt.Columns.Count < colIdx)
        {
            DataColumn col = dt.Columns.Add();
            col.ColumnName = dt.Columns.Count.ToString();
        }
        if (dt.Rows.Count > 0)
        {
            while (dt.Rows[0].ItemArray.Length < colIdx)
                dt.Rows[0][dt.Rows[0].ItemArray.Length] = "";
        }
        DataRow row;
        if (rowIdx < dt.Rows.Count)
        {
            row = dt.Rows[rowIdx];
            row[colIdx - 1] = name;
        }
        else
        {
            row = dt.NewRow();
            row[colIdx - 1] = name;
            dt.Rows.Add(row);
        }
    }
    private void buttonStart_Click(object sender, EventArgs e)
    {
        Dictionary<string, DataTable> workers = new Dictionary<string, DataTable>();
        
        DataTable dt = new DataTable();
        AddRow(dt, "Bob Jones", "Jane Jones", "Jim Jones");
        AddRow(dt, "Joe Jones", "", "John Jones");
        workers.Add("Foo", dt);
        AddToColumn(dt, 0, 4, "Testing"); // Use this if you have to add by column
        dt = new DataTable();
        AddRow(dt, "Worker Bee1",  "Worker Bee2");
        workers.Add("Bar", dt);
        string tabName = "Foo";
        dataGridView1.DataSource = workers.FirstOrDefault(x => x.Key == tabName).Value;
    }
