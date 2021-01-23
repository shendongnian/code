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
    private void buttonStart_Click(object sender, EventArgs e)
    {
        Dictionary<string, DataTable> workers = new Dictionary<string, DataTable>();
        
        DataTable dt = new DataTable();
        AddRow(dt, "Bob Jones", "Jane Jones", "Jim Jones");
        AddRow(dt, "Joe Jones", "", "John Jones");
        workers.Add("Foo", dt);
        dt = new DataTable();
        AddRow(dt, "Worker Bee1",  "Worker Bee2");
        workers.Add("Bar", dt);
        string tabName = "Foo";
        dataGridView1.DataSource = workers.FirstOrDefault(x => x.Key == tabName).Value;
    }
