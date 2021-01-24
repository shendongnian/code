    string server = ".";
    string db = "TestDB";
    private void Form1_Load(object sender, System.EventArgs e)
    {
        var connection = $"SERVER={server};DATABASE={db};Integrated Security=true";
        //Hanlde combo box selected index changed
        comboBox1.SelectedIndexChanged += (obj1, args1) =>
        {
            dataGridView1.DataSource = null;
            if (comboBox1.SelectedIndex > -1)
            {
              //Fill data table and show data in data grid view
              var data = GetDataTable($"SELECT * FROM {comboBox1.SelectedValue}", connection);
              dataGridView1.Columns.Clear();
              dataGridView1.DataSource = data;
            }
            //Clear existing items of context menu strip
            var items = contextMenuStrip1.Items.Cast<ToolStripItem>().ToList();
            contextMenuStrip1.Items.Clear();
            items.ForEach(x => x.Dispose());
            //Add the columns to context menu strip
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                var item = (ToolStripMenuItem)contextMenuStrip1.Items.Add(c.HeaderText);
                item.Tag = c.Name;
                item.Checked = c.Visible;
                item.CheckOnClick = true;
                //Hanlde CheckStateChanged event of context menu strip items
                item.CheckStateChanged += (obj, args) =>
                {
                    var i = (ToolStripMenuItem)obj;
                    dataGridView1.Columns[(string)i.Tag].Visible = i.Checked;
                };
            }
        };
        //Load table names
        var tables = GetDataTable("SELECT Name FROM Sys.Tables", connection);
        comboBox1.ValueMember = "Name";
        comboBox1.DisplayMember = "Name";
        comboBox1.DataSource = tables;
        //Show context menu strip on right click on data grid veiw header
        dataGridView1.CellMouseClick += (obj, args) =>
        {
            if (args.RowIndex == -1 && args.Button == MouseButtons.Right)
                contextMenuStrip1.Show(Cursor.Position);
        };
    }
    DataTable GetDataTable(string commandText, string connectionString)
    {
        using (var da = new SqlDataAdapter(commandText, connectionString))
        {
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
