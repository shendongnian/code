    private void Form1_Load(object sender, EventArgs e)
    {
        //Get data
        var data = new[] {
            new { Title="Stackoverflow", Location = @"https://www.Stackoverflow.com"},
            new { Title="Windows Folder", Location = @"C:\Windows"},
            new { Title="Network Share", Location = @"\\127.0.0.1"},
        };
        // Add columns
        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
        {
            Name = "TitleColumn", DataPropertyName = "Title", HeaderText = "Title"
        });
        dataGridView1.Columns.Add(new DataGridViewLinkColumn()
        {
            Name = "LocationColumn", DataPropertyName = "Location", HeaderText = "Location"
        });
        //Handle click on link
        dataGridView1.CellContentClick += (obj, args) =>
        {
            if (args.RowIndex < 0 || args.ColumnIndex < 0)
                return;
            if (dataGridView1.Columns[args.ColumnIndex].Name != "LocationColumn")
                return;
            var value = $"{dataGridView1[args.ColumnIndex, args.RowIndex].Value}";
            if (Uri.TryCreate(value, UriKind.Absolute, out Uri uri))
                System.Diagnostics.Process.Start(value);
        };
        //Show data
        dataGridView1.DataSource = data.ToList();
    }
