        public Form1()
        {
            InitializeComponent();
            dataGridView1.CellValueChanged +=new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("col1"));
            dt.Columns.Add(new DataColumn("col2"));
            dt.Columns.Add(new DataColumn("col3"));
            var r1 = dt.NewRow();
            r1["col1"] = "a1";
            r1["col2"] = "b1";
            r1["col3"] = "c1";
            var r2 = dt.NewRow();
            r2["col1"] = "a2";
            r2["col2"] = "b2";
            r2["col3"] = "c2";
            var r3 = dt.NewRow();
            r3["col1"] = "a3";
            r3["col2"] = "b3";
            r3["col3"] = "c3";
            dt.Rows.Add(r1);
            dt.Rows.Add(r2);
            dt.Rows.Add(r3);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var dataGrid = (DataGridView)sender;
            var dataGridColumn = dataGrid.Columns[e.ColumnIndex];
            dataGrid.Sort(dataGridColumn, ListSortDirection.Ascending);
        }
